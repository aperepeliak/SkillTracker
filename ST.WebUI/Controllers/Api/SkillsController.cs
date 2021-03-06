﻿using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    public class SkillsController : ApiController
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        { _skillService = skillService; }

        [HttpPost]
        public IEnumerable<SkillDto> GetSkillsByCategory(int id)
            => _skillService.GetAll(id);

        [HttpGet]
        public IHttpActionResult ValidateUnique(string name, int categoryId)
            => Ok(_skillService.IsUnique(name, categoryId));
    }
}
