using Microsoft.AspNet.Identity;
using ST.BLL.DTOs;
using ST.BLL.Infrastructure;
using ST.BLL.Interfaces;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    [Authorize(Roles = SecurityRoles.Developer)]
    public class SkillRatingsController : ApiController
    {
        private readonly IDeveloperService _devService;

        public SkillRatingsController(IDeveloperService devService)
        {
            _devService = devService;
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            var skillRating = _devService.GetSkillRating(User.Identity.GetUserId(), id);

            if (skillRating == null)
                return NotFound();

            _devService.DeleteSkillRating(User.Identity.GetUserId(), id);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Update(SkillRatingDto dto)
        {
            _devService.UpdateSkillRating(User.Identity.GetUserId(), 
                                          dto.SkillId, dto.Rating);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult ValidateUnique(int skillId)
        {
            return Ok(_devService.IsSkillRatingUnique(User.Identity.GetUserId(), skillId));
        }
    }
}
