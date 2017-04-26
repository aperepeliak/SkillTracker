using AutoMapper;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    public class ReportsController : ApiController
    {
        private IDeveloperService _devService;
        public ReportsController(IDeveloperService devService)
        {
            _devService = devService;
        }

        public IEnumerable<DeveloperViewModel> Search(IEnumerable<SkillRatingFilterDto> filters)
        {
            return _devService.SearchByFilters(filters)
                .Select(Mapper.Map<DeveloperDto, DeveloperViewModel>);
        }
    }
}
