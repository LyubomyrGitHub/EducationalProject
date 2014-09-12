using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Antlr.Runtime.Tree;
using EducationalProject.DataInfo;

namespace EducationalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult RolePermissions()
        {
            var roleName = Roles.GetRolesForUser().FirstOrDefault();
            if (roleName != null)
            {
                var roleType =
                    (RoleType) Enum.Parse(typeof (RoleType), roleName);
                switch (roleType)
                {
                    case RoleType.Administrator:
                    {
                        return RedirectToAction("AdminSpace", "Admin");
                    }
                    case RoleType.Teacher:
                    {
                        return RedirectToAction("TeacherSpace", "Teacher");
                    }
                    case RoleType.User:
                    {
                        return RedirectToAction("UserSpace", "User");
                    }
                    default:
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
