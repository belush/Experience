using Business.Logic;
using DAL.Entity;
using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experience.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        TaskLogic logic = new TaskLogic();
        UserLogic userLogic = new UserLogic();

        public ActionResult Index()
        {
            ViewBag.NumberOfTasks = logic.GetNumberOfTasks();
            return View(logic.GetTasks());
        }

        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Flight/Create

        [HttpPost]
        public ActionResult Create(Task task)
        {


            try
            {
                // TODO: Add insert logic here
                string name = User.Identity.Name;
                User user = userLogic.GetUserByName(name);
                if (user != null)
                {
                    task.Customer = user;
                    logic.AddTask(task);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(logic.GetTaskById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {

            logic.DeleteTask(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Task task = logic.GetTaskById(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Task task, FormCollection collection)
        {
            try
            {
                logic.EditTask(task);
                //
                //

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Details(int id)
        {

            return View(logic.GetTaskById(id));
        }

        // list of subscribers to work
        public ActionResult Work()
        {

            List<Task> tasks = logic.GetWorks();
            List<TaskUserView> works = new List<TaskUserView>();
            foreach (Task task in tasks)
            {
                TaskUserView work = new TaskUserView();
                work.TaskId = task.TaskId;
                work.AddDate = task.AddDate;
                work.Customer = task.Customer;
                work.Description = task.Description;
                work.Name = task.Name;
                User user = userLogic.GetUserById(task.PerfomerId);
                work.PerfomerName = user.UserName;
                works.Add(work);
            }
            ViewBag.NumberOfDone = works.Count;
            return View(works);
        }

        [HttpPost]
        public ActionResult Details(Task task)
        {
            try
            {
                string name = User.Identity.Name;
                User user = userLogic.GetUserByName(name);
                task.PerfomerId = user.UserId;
                logic.EditTask(task);
            }
            catch
            {


            }

            return RedirectToAction("Index");
        }

    }
}
