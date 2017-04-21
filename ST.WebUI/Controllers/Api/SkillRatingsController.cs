﻿using Microsoft.AspNet.Identity;
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
    public class SkillRatingsController : ApiController
    {
        private IDeveloperService _devService;
        public SkillRatingsController(IDeveloperService devService)
        {
            _devService = devService;
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            var dto = _devService.GetSkillRating(User.Identity.GetUserId(), id);

            if (dto == null)
                return NotFound();

            _devService.DeleteSkillRating(dto);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Update(SkillRatingDto dto)
        {
            var developerId = User.Identity.GetUserId();

            _devService.UpdateSkillRating(developerId, dto.SkillId, dto.Rating);

            return Ok();
        }
    }
}
