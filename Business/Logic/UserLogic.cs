using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Logic
{
    public class UserLogic : Logic
    {
        public User GetUserByName(string name)
        {
            return r.GetUserByName(name);
        }

        public User GetUserById(int id)
        {
            return r.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return r.GetUsers();
        }

        public int GetNumberOfUsers()
        {
            int number = r.GetNumberOfUsers();
            return number;
        }

        public List<User> GetCustomers()
        {
            return r.GetCustomers();
        }


        public int GetNumberOfCustomers()
        {
            int number = r.GetCustomers().Count;
            return number;
        }
    }
}