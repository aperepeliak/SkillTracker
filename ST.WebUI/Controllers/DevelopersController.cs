using Microsoft.AspNet.Identity;
using ST.BLL.Infrastructure;
using ST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = SecurityRoles.Developer)]
    public class DevelopersController : Controller
    {
        private IDeveloperService _devService;

        public DevelopersController(IDeveloperService devService)
        {
            _devService = devService;
        }

        public ActionResult DeveloperProfile()
        {
            string user = User.Identity.GetUserId();

            var skillRatings = _userService.Get

            var developerViewModel = new DeveloperViewModel
            {
                FirstName = user

            };

            return View(developerViewModel);
        }
    }
}