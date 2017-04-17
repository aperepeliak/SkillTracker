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
        public IHttpActionResult GetSkillsByCategory(int id)
        {
            var skills = _skillService.GetByCategory(id);

            return Content(HttpStatusCode.OK, skills);
        }
    }
}
