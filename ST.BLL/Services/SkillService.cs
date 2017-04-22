using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;
using ST.DAL.Models;
using AutoMapper;

namespace ST.BLL.Services
{
    public class SkillService : ISkillService
    {
        IUnitOfWork _db;
        public SkillService(IUnitOfWork db)
        {
            _db = db;
        }

        public void Add(SkillDto dto)
        {
            _db.Skills.Add(Mapper.Map<Skill>(dto));
            _db.Save();
        }

        public IEnumerable<SkillDto> GetAll()
        {
            return _db.Skills.GetAll().Select(Mapper.Map<Skill, SkillDto>);
        }

        public IEnumerable<SkillDto> GetByCategory(int categoryId)
        {
            return _db.Skills.GetAll()
                .Where(s => s.CategoryId == categoryId)
                .Select(Mapper.Map<Skill, SkillDto>);
        }

        public SkillDto GetById(int id)
        {
            return Mapper.Map<SkillDto>(_db.Skills.GetById(id));
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
