using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Logic
{
    public class TaskLogic : Logic
    {
        public List<Task> GetTasks()
        {
            return r.GetTasks();
        }

        public Task GetTaskById(int id)
        {
            return r.GetTaskById(id);
        }

        public int GetNumberOfTasks()
        {
            return r.GetNumberOfTasks();
        }

        public List<Task> GetWorks()
        {
            List<Task> tasks = r.GetTasks().Where(t => t.PerfomerId != null).ToList();
            return r.GetTasks();
        }
        

        public void EditTask(Task task)
        {
            r.EditTask(task);
        }

        public void DeleteTask(int taskId)
        {
            Task task = r.GetTaskById(taskId);
            if (task != null)
            {
                r.DeleteTask(task);
            }
        }

        public void AddTask(Task task)
        {
            r.AddTask(task);
        }

        ////
        public List<UserType> GetUserTypes()
        {
            return r.GetUserTypes();
        }

    }
}