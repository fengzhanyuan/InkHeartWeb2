using InkHeart.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InkHeart.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: Login

        public IUserService userService { get; set; }//autofac属性注入
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult Forget()
        {
            return View("Forget");
        }
    }
}