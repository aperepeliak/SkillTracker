using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    public class SkillsController : ApiController
    {
        private ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public IEnumerable<SkillDto> GetSkillsByCategory(int id)
        {
            return _skillService.GetByCategory(id);
        }

        [HttpGet]
        public IHttpActionResult ValidateUnique(string name, int categoryId)
        {
            return Ok(_skillService.IsUnique(name, categoryId));
        }
    }
}
