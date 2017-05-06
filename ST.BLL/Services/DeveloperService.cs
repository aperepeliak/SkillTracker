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
        IUserUnitOfWork _userUnitOfWork;

        public DeveloperService(IUserUnitOfWork userUnitOfWork)
        { _userUnitOfWork = userUnitOfWork; }

        public void AddSkillRating(string developerId, SkillRatingDto dto)
        {
            _userUnitOfWork.SkillRatings.Add(new SkillRating
            {
                DeveloperId = developerId,
                SkillId = dto.SkillId,
                Rating = dto.Rating
            });

            _userUnitOfWork.Save();
        }

        public SkillRatingDto GetSkillRating(string developerId, int skillId)
        {
            SkillRatingDto dto = null;

            var skillRating = _userUnitOfWork.SkillRatings
                                             .Get(developerId, skillId);

            if (skillRating != null)
                dto = Mapper.Map<SkillRatingDto>(skillRating);

            return dto;
        }

        public void DeleteSkillRating(string developerId, int skillId)
        {
            var skillRating = _userUnitOfWork.SkillRatings.Get(developerId, skillId);

            if (skillRating != null)
            {
                _userUnitOfWork.SkillRatings.Delete(skillRating);
                _userUnitOfWork.Save();
            }
        }

        public void UpdateSkillRating(string developerId, int skillId, int newRating)
        {
            var skillRating = _userUnitOfWork.SkillRatings.Get(developerId, skillId);

            if (skillRating != null)
            {
                skillRating.Rating = newRating;
                _userUnitOfWork.Save();
            }
        }

        public IEnumerable<DeveloperDto> SearchByTerm(string searchTerm)
        {
            IEnumerable<Developer> selectedDevs = null;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                selectedDevs = _userUnitOfWork.Developers.GetAll();
            }
            else
            {
                selectedDevs = _userUnitOfWork.Developers.GetAll()
                .Where(d =>
                        d.User.Email.Contains
                            (searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        d.User.FirstName.Contains
                            (searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        d.User.LastName.Contains
                            (searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        d.SkillRatings.Any(s => s.Skill.Name.Contains
                            (searchTerm, StringComparison.OrdinalIgnoreCase)));
            }

            return selectedDevs.Select(Mapper.Map<Developer, DeveloperDto>);
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

            return _userUnitOfWork.Developers.FilterBy(predicate)
                .Select(Mapper.Map<Developer, DeveloperDto>);
        }

        public DeveloperDto GetDeveloper(string id)
            => Mapper.Map<DeveloperDto>(_userUnitOfWork.Developers.GetById(id));

        public DeveloperDto GetDeveloperByEmail(string email)
            => Mapper.Map<DeveloperDto>(_userUnitOfWork.Developers.GetByEmail(email));

        public bool IsSkillRatingUnique(string developerId, int skillId)
            => !_userUnitOfWork.SkillRatings
                               .GetForDeveloper(developerId)
                               .Any(sr => sr.SkillId == skillId);
    }
}
