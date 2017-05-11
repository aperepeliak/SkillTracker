using AutoMapper;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    public class ReportsController : ApiController
    {
        private readonly IDeveloperService _devService;

        public ReportsController(IDeveloperService devService)
        {
            _devService = devService;
        }

        [HttpPost]
        public IEnumerable<DeveloperViewModel> Search(IEnumerable<ReportFilterDto> filters)
        {
            return _devService.SearchByFilters(filters)
                .Select(Mapper.Map<DeveloperDto, DeveloperViewModel>);
        }
    }   
}
