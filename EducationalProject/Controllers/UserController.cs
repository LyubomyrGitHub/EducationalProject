using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationalProject.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "User")]
        public ActionResult UserSpace()
        {
            return View();
        }
	}
}