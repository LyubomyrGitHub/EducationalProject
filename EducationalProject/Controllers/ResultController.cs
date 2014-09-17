using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EducationalProject.Models;
using WebMatrix.WebData;

namespace EducationalProject.Controllers
{
    public class ResultController : Controller
    {
        [Authorize(Roles = "User")]
        public ActionResult Results()
        {
            var resultsWrapper = new List<ResultsWrapper>();
            using (var db = new UsersContext())
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                var resultList = db.TestsResults.Where(result=>result.User.UserId==userId)
                    .OrderByDescending(date => date.DatePassing).ToList().Take(7);

                resultsWrapper.AddRange(resultList.Select(result => new ResultsWrapper
                {
                    TestName = result.Test.TestName,
                    DatePassing = result.DatePassing,
                    Passed = result.Passed,
                    PercentTaken = result.PercentTaken
                }));
            }
            return View(resultsWrapper);
        }
	}
}