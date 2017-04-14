using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;
using ST.DAL.Models;

namespace ST.BLL.Services
{
    public class SkillService : ISkillService
    {
        IUnitOfWork _db;
        public SkillService(IUnitOfWork db)
        {
            _db = db;
        }

        public void Add(SkillDto skillDto)
        {
            _db.Skills.Add(new Skill
            {
                Name       = skillDto.Name,
                CategoryId = skillDto.CategoryId
            });

            _db.Save();
        }

        public IEnumerable<SkillDto> GetAll()
        {
            return _db.Skills.GetAll().Select(s => new SkillDto
            {
                Id           = s.Id,
                Name         = s.Name,
                CategoryId   = s.CategoryId,
                CategoryName = s.Category.Name
            });
        }

        public IEnumerable<SkillDto> GetByCategory(int categoryId)
        {
            return _db.Skills.GetAll()
                .Where(s => s.CategoryId == categoryId)
                .Select(s => new SkillDto
                {
                    Id           = s.Id,
                    Name         = s.Name,
                    CategoryId   = s.CategoryId,
                    CategoryName = s.Category.Name
                });
        }

        public SkillDto GetById(int id)
        {
            var skill = _db.Skills.GetById(id);

            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                CategoryId = skill.CategoryId
            };
        }

        public void Remove(SkillDto skillDto)
        {
            var skill = _db.Skills.GetById(skillDto.Id);

            if (skill != null)
            {
                _db.Skills.Delete(skill);
                _db.Save();
            }
        }

        public void Update(SkillDto skillDto)
        {
            var skill = _db.Skills.GetById(skillDto.Id);

            if (skill != null)
            {
                skill.Name = skillDto.Name;
                skill.CategoryId = skillDto.CategoryId;
                _db.Save();
            }
        }
    }
}
