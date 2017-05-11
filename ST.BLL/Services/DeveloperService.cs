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
        private readonly IUserUnitOfWork _unitOfWork;

        public DeveloperService(IUserUnitOfWork userUnitOfWork)
        { _unitOfWork = userUnitOfWork; }

        public void AddSkillRating(string developerId, SkillRatingDto dto)
        {
            _unitOfWork.SkillRatings.Add(new SkillRating
            {
                DeveloperId = developerId,
                SkillId = dto.SkillId,
                Rating = dto.Rating
            });

            _unitOfWork.Save();
        }

        public SkillRatingDto GetSkillRating(string developerId, int skillId)
        {
            SkillRatingDto dto = null;

            var skillRating = _unitOfWork.SkillRatings
                                         .Get(developerId, skillId);

            if (skillRating != null)
                dto = Mapper.Map<SkillRatingDto>(skillRating);

            return dto;
        }

        public void DeleteSkillRating(string developerId, int skillId)
        {
            var skillRating = _unitOfWork.SkillRatings.Get(developerId, skillId);

            if (skillRating != null)
            {
                _unitOfWork.SkillRatings.Delete(skillRating);
                _unitOfWork.Save();
            }
        }

        public void UpdateSkillRating(string developerId, int skillId, int newRating)
        {
            var skillRating = _unitOfWork.SkillRatings.Get(developerId, skillId);

            if (skillRating != null)
            {
                skillRating.Rating = newRating;
                _unitOfWork.Save();
            }
        }

        public IEnumerable<DeveloperDto> SearchByTerm(string searchTerm)
        {
            IEnumerable<Developer> selectedDevs = null;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                selectedDevs = _unitOfWork.Developers.GetAll();
            }
            else
            {
                selectedDevs = _unitOfWork.Developers.GetAll()
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

        public IEnumerable<DeveloperDto> SearchByFilters
                        (IEnumerable<ReportFilterDto> filters)
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

            return _unitOfWork.Developers.FilterBy(predicate)
                .Select(Mapper.Map<Developer, DeveloperDto>);
        }

        public DeveloperDto GetDeveloper(string id)
            => Mapper.Map<DeveloperDto>(_unitOfWork.Developers.GetById(id));

        public DeveloperDto GetDeveloperByEmail(string email)
            => Mapper.Map<DeveloperDto>(_unitOfWork.Developers.GetByEmail(email));

        public bool IsSkillRatingUnique(string developerId, int skillId)
            => !_unitOfWork.SkillRatings
                               .GetForDeveloper(developerId)
                               .Any(sr => sr.SkillId == skillId);
    }
}
