using AutoMapper;
using ST.BLL.DTOs;
using ST.BLL.Infrastructure;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = SecurityRoles.Manager)]
    public class ManagersController : Controller
    {
        private IDeveloperService _devService;
        private ICategoryService _categoryService;
        public ManagersController(IDeveloperService devService, ICategoryService categoryService)
        {
            _devService = devService;
            _categoryService = categoryService;
        }

        public ActionResult Search(string searchTerm = null, int page = 1)
        {
            int numberOfItemsPerPage = 4;
            var selectedDevs = _devService.SearchByTerm(searchTerm);

            var viewModel = new DevelopersViewModel
            {
                SearchTerm = searchTerm,
                Developers = selectedDevs.
                                Select(Mapper.Map<DeveloperDto, DeveloperViewModel>)
                                .ToPagedList(page, numberOfItemsPerPage)
            };

            return View(viewModel);
        }

        public ActionResult DeveloperProfile(string email)
        {
            var developerViewModel = Mapper.Map<DeveloperDto, DeveloperViewModel>
                                            (_devService.GetDeveloperByEmail(email));

            return View(developerViewModel);
        }

        public ActionResult CreateReport()
        {
            var viewModel = new ReportFormViewModel()
            {
                Categories = _categoryService.GetAll().AsEnumerable()
            };

            return View("ReportForm", viewModel);
        }
    }
}