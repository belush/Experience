using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experience.DAL
{
    public class Repository
    {
        ExperienceContext db = new ExperienceContext();

        /// <summary>
        /// TASK
        /// </summary>
        /// <returns></returns>
        /// добавить что то
        /// hfdshfjsd
        public List<Task> GetTasks()
        {
            return db.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            return db.Tasks.FirstOrDefault(t => t.TaskId == id);
        }

        public int GetNumberOfTasks()
        {
            int number = db.Tasks.Count();

            return number;
        }

        public void AddTask(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void EditTask(Task task)
        {
            db.Entry(task).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            db.Tasks.Remove(task);
            db.SaveChanges();
        }

        ////User Types
        public List<UserType> GetUserTypes()
        {
            return db.UserTypes.ToList();
        }

        ////USER
        public User GetUserByName(string name)
        {
            return db.Users.FirstOrDefault(u => u.UserName == name);
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public List<User> GetCustomers()
        {
            List<User> users = GetUsers();
            List<User> customers = new List<User>();
            List<Task> tasks = GetTasks();
            List<int> customerIds = new List<int>();

            customerIds = tasks.Select(c => c.Customer.UserId).ToList();

            foreach (int item in customerIds)
            {
                customers.Add(users.FirstOrDefault(x => x.UserId == item));
            }

            return customers;
        }

        public List<User> GetPerformers()
        {
            List<User> users = GetUsers();
            List<User> performers = new List<User>();
            performers = users.Where(x => x.isReady == true).ToList();            

            return performers;
        }

        public int GetNumberOfUsers()
        {
            int number = db.Users.Count();
            return number;
        }

    }
}