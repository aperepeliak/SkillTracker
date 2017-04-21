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
    [Authorize(Roles = SecurityRoles.Manager)]
    public class ManagersController : Controller
    {
        private IDeveloperService _devService;
        public ManagersController(IDeveloperService devService)
        {
            _devService = devService;
        }

        //public ActionResult Search(string searchTerm = null)
        //{
        //    var selectedDevs = _devService.SearchByTerm(searchTerm);

        //    //var viewModel = new DevelopersViewModel
        //    //{
        //    //    SearchTerm = searchTerm,
        //    //    Developers = selectedDevs.Select(d => new DeveloperViewModel
        //    //    {
        //    //        Email        = d.Email,
        //    //        FirstName    = d.FirstName,
        //    //        LastName     = d.LastName,
        //    //        SkillRatings = d.SkillRatings.Select(s => new )
        //    //    });
        //    //}

        //    //var viewModel = selectedDevs.Select(d => new DeveloperViewModel
        //    //{
        //    //    Email = selectedDevs.Email,
        //    //    FirstName = selectedDevs.FirstName,
        //    //    LastName = selectedDevs.LastName,
        //    //    SkillRatings = selectedDevs.SkillRatings
        //    //});

        //    return View(viewModel);
        //}
    }
}