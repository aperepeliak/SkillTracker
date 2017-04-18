using Microsoft.AspNet.Identity;
using ST.BLL.DTOs;
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
        private ICategoryService _categoryService;

        public DevelopersController(IDeveloperService devService, IUserService userService, ICategoryService categoryService)
        {
            _devService = devService;
            _userService = userService;
            _categoryService = categoryService;
        }

        public ActionResult DeveloperProfile()
        {
            string userId = User.Identity.GetUserId();

            var user = _userService.GetUserById(userId);
            var userSkillRatings = _devService.GetSkillRatings(userId);

            var developerViewModel = new DeveloperViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SkillRatings = userSkillRatings
            };

            return View(developerViewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new SkillRatingFormViewModel
            {
                Categories = _categoryService.GetAll()
            };

            return View("SkillRatingForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillRatingFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _categoryService.GetAll();
                return View("SkillRatingForm", viewModel);
            }

            var skillRatingDto = new SkillRatingDto
            {
                DeveloperId = User.Identity.GetUserId(),
                SkillId = viewModel.SkillId,
                Rating = viewModel.Rating,
            };

            _devService.AddSkillRating(skillRatingDto);

            return RedirectToAction("DeveloperProfile", "Developers");
        }
    }
}