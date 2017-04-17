using Microsoft.AspNet.Identity;
using ST.BLL.Infrastructure;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
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
        private IUserService _userService;

        public DevelopersController(IDeveloperService devService, IUserService userService)
        {
            _devService = devService;
            _userService = userService;
        }

        public ActionResult DeveloperProfile()
        {
            string userId = User.Identity.GetUserId();

            var user = _userService.GetUserById(userId);
            var userSkillRatings = _devService.GetSkillRatingsById(userId);

            var developerViewModel = new DeveloperViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SkillRatings = userSkillRatings
            };

            return View(developerViewModel);
        }
    }
}