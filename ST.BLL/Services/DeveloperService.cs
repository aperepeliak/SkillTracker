using ST.BLL.Interfaces;
using System.Linq;
using ST.BLL.DTOs;
using ST.DAL.Interfaces;
using System.Collections.Generic;
using ST.DAL.Models;
using AutoMapper;
using System;
using ST.BLL.Infrastructure.Extensions;

namespace ST.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        IUnitOfWork _db;
        public DeveloperService(IUnitOfWork db)
        {
            _db = db;
        }

        public void AddSkillRating(SkillRatingDto dto)
        {
            _db.SkillRatings.Add(Mapper.Map<SkillRating>(dto));
            _db.Save();
        }

        public SkillRatingDto GetSkillRating(string developerId, int skillId)
        {
            SkillRatingDto dto = null;

            var skillRating = _db.SkillRatings.Get(developerId, skillId);

            if (skillRating != null)
                dto = Mapper.Map<SkillRatingDto>(skillRating);

            return dto;
        }

        public void DeleteSkillRating(SkillRatingDto dto)
        {
            var skillRating = _db.SkillRatings.Get(dto.DeveloperId, dto.SkillId);

            if (skillRating != null)
            {
                _db.SkillRatings.Delete(skillRating);
                _db.Save();
            }
        }

        public void UpdateSkillRating(string developerId, int skillId, int newRating)
        {
            var skillRating = _db.SkillRatings.Get(developerId, skillId);

            if (skillRating != null)
            {
                skillRating.Rating = newRating;
                _db.Save();
            }
        }

        public IEnumerable<DeveloperDto> SearchByTerm(string searchTerm)
        {
            IEnumerable<Developer> selectedDevs = null;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                selectedDevs = _db.Developers.GetAll();
            }
            else
            {
                selectedDevs = _db.Developers.GetAll()
                .Where(d => 
                 d.User.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)      ||
                 d.User.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)  ||
                 d.User.LastName.Contains (searchTerm, StringComparison.OrdinalIgnoreCase)  ||
                 d.SkillRatings.Any(s => s.Skill.Name
                                    .Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
            }

            return selectedDevs.Select(Mapper.Map<Developer, DeveloperDto>);
        }

        public DeveloperDto GetDeveloper(string id)
        {
            return Mapper.Map<DeveloperDto>(_db.Developers.GetById(id));
        }

        public DeveloperDto GetDeveloperByEmail(string email)
        {
            return Mapper.Map<DeveloperDto>(_db.Developers.GetByEmail(email));
        }
    }
}
