using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experience.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        UserLogic logic = new UserLogic();

        public ActionResult Index()
        {
            ViewBag.NumberOfUsers = logic.GetNumberOfUsers();
            return View(logic.GetUsers());
        }

        public ActionResult Customer()
        {
            ViewBag.NumberOfUsers = logic.GetNumberOfCustomers();
            return View(logic.GetCustomers());
        }

    }
}
