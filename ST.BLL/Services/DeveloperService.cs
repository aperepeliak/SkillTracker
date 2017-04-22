using ST.BLL.Interfaces;
using System.Linq;
using ST.BLL.DTOs;
using ST.DAL.Interfaces;
using System.Collections.Generic;
using ST.DAL.Models;
using System;
using AutoMapper;

namespace ST.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        IUnitOfWork _db;
        public DeveloperService(IUnitOfWork db)
        {
            _db = db;
        }

        public IDictionary<string, List<SkillRatingDto>> GetSkillRatings(string id)
        {
            return _db.SkillRatings.GetForDeveloper(id)
                .Select(s => new SkillRatingDto
                {
                    CategoryName = s.Skill.Category.Name,
                    DeveloperId = s.DeveloperId,
                    Rating = s.Rating,
                    SkillId = s.SkillId,
                    SkillName = s.Skill.Name
                })
                .OrderBy(s => s.CategoryName)
                .ThenByDescending(s => s.Rating)
                .GroupBy(s => s.CategoryName)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void AddSkillRating(SkillRatingDto dto)
        {
            _db.SkillRatings.Add(new SkillRating
            {
                DeveloperId = dto.DeveloperId,
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
            {
                dto = new SkillRatingDto
                {
                    DeveloperId = skillRating.DeveloperId,
                    SkillId = skillRating.SkillId,
                    Rating = skillRating.Rating
                };
            }

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
                .Where(d => d.User.Email == searchTerm ||
                            d.User.FirstName == searchTerm ||
                            d.User.LastName == searchTerm ||
                            d.SkillRatings.Any(s => s.Skill.Name == searchTerm));
            }

            //return selectedDevs.Select(Mapper.Map<Developer, DeveloperDto>);

            return selectedDevs.Select(d => new DeveloperDto
            {
                Email = d.User.Email,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                SkillRatings = d.SkillRatings
                                .Select(s => new SkillRatingDto
                                {
                                    CategoryName = s.Skill.Category.Name,
                                    DeveloperId = s.DeveloperId,
                                    Rating = s.Rating,
                                    SkillId = s.SkillId,
                                    SkillName = s.Skill.Name
                                })
                                .OrderBy(s => s.CategoryName)
                                .ThenByDescending(s => s.Rating)
                                .GroupBy(s => s.CategoryName)
                                .ToDictionary(g => g.Key, g => g.ToList())
            });

            //return selectedDevs.Select(d => new DeveloperDto
            //{
            //    Email = d.User.Email,
            //    FirstName = d.User.FirstName,
            //    LastName = d.User.LastName,
            //    SkillRatings = _db.SkillRatings.GetForDeveloper(d.DeveloperId)
            //                    .Select(s => new SkillRatingDto
            //                    {
            //                        CategoryName = s.Skill.Category.Name,
            //                        DeveloperId = s.DeveloperId,
            //                        Rating = s.Rating,
            //                        SkillId = s.SkillId,
            //                        SkillName = s.Skill.Name
            //                    })
            //                    .OrderBy(s => s.CategoryName)
            //                    .ThenByDescending(s => s.Rating)
            //                    .GroupBy(s => s.CategoryName)
            //                    .ToDictionary(g => g.Key, g => g.ToList())
            //});
        }

        public DeveloperDto GetDeveloper(string id)
        {
            Developer developer = _db.Developers.GetById(id);

            return Mapper.Map<DeveloperDto>(developer);
        }
    }
}
