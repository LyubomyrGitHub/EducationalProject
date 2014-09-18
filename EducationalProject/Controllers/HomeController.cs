using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Antlr.Runtime.Tree;
using EducationalProject.DataInfo;
using EducationalProject.Models;

namespace EducationalProject.Controllers
{
    public class HomeController : Controller
    {

        EducationalProjectContext db = new EducationalProjectContext();
        

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
            var contacts = db.Contacts.ToList();
            ViewBag.Message = "Your contact page.";
            return View(contacts);
        }

        public ActionResult Literature()
        {

            var data = db.BookSections.ToList();
            var books = db.Books;

            var q =
                from e in data
                from et in db.Books.ToList()
                where e.BookSectionId == et.BookSectionId
                select
                    new BooksWrapper()
                    {
                        Name = et.Name,
                        Author = et.Author,
                        BookSection = e.Name,
                        Description = et.Description
                    };
            q = q.ToList();

            ViewBag.Message = "Your contact page.";
            return View(q);
        }
        public ActionResult Lectures()
        {
            var lectures = db.Lectures.ToList();
            ViewBag.Message = "Your contact page.";
            return View(lectures);
        }
        public class BooksWrapper
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string BookSection { get; set; }
         //   public List<string> Books { get; set; }
        }
        public JsonResult GetJson()
        {

            var data = db.BookSections.ToList();
            var books = db.Books;

            var q =
                from e in data
                from et in db.Books.ToList()
                where e.BookSectionId == et.BookSectionId
                select
                    new BooksWrapper()
                    {
                        Name = et.Name,
                        Author = et.Author,
                        BookSection = e.Name,
                        Description = et.Description
                    };
            q = q.ToList();
            //var collection = data.Select(x => new
            //{
            //    x.Name,
            //    Books = books.Select(item => new
            //    {
            //        item.Name,
            //        item.Description,
            //        item.Author
            //    }).Where(x.BookSectionId == sectionid)
                
            //});

            //var bookList = collection.Select(book => new BooksWrapper
            //{
            //    Name = book.Name, Author = "autho", Description = "Desc"
            //}).ToList();

            var json = Json(q, JsonRequestBehavior.AllowGet);


            return json;
        }
    }
}
