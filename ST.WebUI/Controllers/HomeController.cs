using Microsoft.AspNet.Identity;
using ST.WebUI.ViewModels;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeveloperProfile()
        {
            string user = User.Identity.GetUserId();
            var skillRatings = 

            var developerViewModel = new DeveloperViewModel
            {
                FirstName = user

            };

            return View(developerViewModel);
        }
    }
}