using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            var developerViewModel = new DeveloperViewModel
            {


            };

            return View(developerViewModel);
        }
    }
}