using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using Experience.Models;
using System.Web.Security;
using Experience.DAL;

namespace Experience.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {

            SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
            SimpleMembershipProvider membership = (SimpleMembershipProvider)Membership.Provider;

            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<ExperienceContext>(null);

                try
                {
                    using (var context = new ExperienceContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                    WebSecurity.InitializeDatabaseConnection("ExperienceContext", "User", "UserId", "UserName", autoCreateTables: true);


                    if (!roles.RoleExists("Admin"))
                    {
                        roles.CreateRole("Admin");/*илиRoles.CreateRole("Admin"); */
                    }
                    if (!roles.RoleExists("User"))
                    {
                        roles.CreateRole("User");
                    }
                    if (!roles.RoleExists("Customer"))
                    {
                        roles.CreateRole("Customer");
                    }
                    if (!roles.RoleExists("Perfomer"))
                    {
                        roles.CreateRole("Perfomer");
                    }


                    if (membership.GetUser("admin1", false) == null)
                    {

                        WebSecurity.CreateUserAndAccount("admin1", "admin1admin1",
                            new
                            {

                                Surname = "admin",
                                PhoneNumber = "11111",
                                Email = "admin"
                                //Type = new Type()
                            });
                        roles.AddUsersToRoles(new[] { "admin1" }, new[] { "Admin" });
                    }

                }

                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
