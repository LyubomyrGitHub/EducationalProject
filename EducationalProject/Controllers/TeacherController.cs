using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EducationalProject.Controllers.Utilities;
using EducationalProject.Models;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace EducationalProject.Controllers
{
    public class TeacherController : Controller
    {
        [Authorize(Roles = "Teacher")]
        public ActionResult TeacherSpace()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult FileUpload()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            var directory = Server.MapPath("~/TestFiles/User=" + userId);
            CreateIfMissing(directory);
            for (var index = 0; index < Request.Files.Count; ++index)
            {
                var file = Request.Files[index];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(directory, fileName);
                    file.SaveAs(path);
                    using (var db = new UsersContext())
                    {
                        try
                        {
                            var test = XmlToTestParser.ParseFromXml(path);
                            test.User = db.UserProfiles.FirstOrDefault(u => u.UserId == userId);
                            test.PathFile = path;
                            db.Tests.Add(test);
                            db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            return RedirectToAction("TeacherSpace", "Teacher");
                        }
                    }
                }
            }
            return RedirectToAction("TeacherSpace", "Teacher");
        }

        private static void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}