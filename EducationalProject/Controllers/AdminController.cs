﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationalProject.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult AdminSpace()
        {
            return View();
        }
	}
}