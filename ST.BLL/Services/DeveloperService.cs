using ST.BLL.Interfaces;
using System.Linq;
using ST.BLL.DTOs;
using ST.DAL.Interfaces;
using System.Collections.Generic;
using ST.DAL.Models;
using AutoMapper;
using System;
using ST.BLL.Infrastructure.Extensions;
using LinqKit;

namespace ST.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        IUnitOfWork _db;
        public DeveloperService(IUnitOfWork db)
        {
            _db = db;
        }

        public void AddSkillRating(string developerId, SkillRatingDto dto)
        {
            _db.SkillRatings.Add(new SkillRating
            {
                DeveloperId = developerId,
                SkillId = dto.SkillId,
                Rating = dto.Rating
            });
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

        public void DeleteSkillRating(string developerId, int skillId)
        {
            var skillRating = _db.SkillRatings.Get(developerId, skillId);

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
                 d.User.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                 d.User.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                 d.User.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
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

        public IEnumerable<DeveloperDto> SearchByFilters(
                                    IEnumerable<ReportFilterDto> filters)
        {
            var predicate = PredicateBuilder.New<Developer>();

            foreach (var filter in filters)
            {
                var temp = filter;

                switch (temp.Comparer)
                {
                    case ComparerType.GreaterThan:
                        predicate = predicate.And(d =>
                        d.SkillRatings.Any(sr => sr.SkillId == temp.SkillId &&
                                            sr.Rating >= temp.Rating));
                        break;

                    case ComparerType.LessThan:
                        predicate = predicate.And(d =>
                        d.SkillRatings.Any(sr => sr.SkillId == temp.SkillId &&
                                             sr.Rating <= temp.Rating));
                        break;

                    case ComparerType.Equals:
                        predicate = predicate.And(d =>
                        d.SkillRatings.Any(sr => sr.SkillId == temp.SkillId &&
                                            temp.Rating == sr.Rating));
                        break;
                }
            }

            return _db.Developers.FilterBy(predicate)
                .Select(Mapper.Map<Developer, DeveloperDto>);
        }
    }
}
