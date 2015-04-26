using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Experience.DAL
{
    public class ExperienceContext : DbContext
    {
        public ExperienceContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}