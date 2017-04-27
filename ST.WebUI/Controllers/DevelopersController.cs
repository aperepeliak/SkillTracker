using AutoMapper;
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
        private ICategoryService _categoryService;

        public DevelopersController(IDeveloperService devService, 
            ICategoryService categoryService)
        {
            _devService = devService;
            _categoryService = categoryService;
        }

        public ActionResult DeveloperProfile()
        {
            var developerViewModel = Mapper.Map<DeveloperDto, DeveloperViewModel>(
                _devService.GetDeveloper(User.Identity.GetUserId()));
            
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
                SkillId = viewModel.SkillId,
                Rating = viewModel.Rating,
            };

            _devService.AddSkillRating(User.Identity.GetUserId(), skillRatingDto);

            return RedirectToAction("DeveloperProfile", "Developers");
        }
    }
}