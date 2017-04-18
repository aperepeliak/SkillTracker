using ST.BLL.Interfaces;
using System.Linq;
using ST.BLL.DTOs;
using ST.DAL.Interfaces;
using System.Collections.Generic;
using ST.DAL.Models;

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
            return _db.Developers.GetById(id).SkillRatings.Select(s => new SkillRatingDto
            {
                DeveloperId = s.DeveloperId,
                SkillId = s.SkillId,
                SkillName = _db.Skills.GetById(s.SkillId).Name,
                CategoryName = _db.Categories.GetById(
                                             _db.Skills.GetById(s.SkillId).CategoryId)
                                             .Name,
                Rating = s.Rating
            })
            .OrderBy(s => s.CategoryName)
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
    }
}
