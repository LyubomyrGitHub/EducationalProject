using System.Web.Mvc;

namespace EducationalProject.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public ActionResult AdminSpace()
        {
            return View();
        }
	}
}