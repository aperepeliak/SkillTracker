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
        ISkillsUnitOfWork _unitOfWork;

        public SkillService(ISkillsUnitOfWork unitOfWork)
        { _unitOfWork = unitOfWork; }

        public void Add(SkillDto dto)
        {
            _unitOfWork.Skills.Add(Mapper.Map<Skill>(dto));
            _unitOfWork.Save();
        }

        public void Update(SkillDto skillDto)
        {
            var skill = _unitOfWork.Skills.GetById(skillDto.Id);

            if (skill != null)
            {
                skill.Name = skillDto.Name;
                skill.CategoryId = skillDto.CategoryId;
                _unitOfWork.Save();
            }
        }

        public void Remove(SkillDto skillDto)
        {
            var skill = _unitOfWork.Skills.GetById(skillDto.Id);

            if (skill != null)
            {
                _unitOfWork.Skills.Delete(skill);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<SkillDto> GetAll()
            => _unitOfWork.Skills
                          .GetAll()
                          .Select(Mapper.Map<Skill, SkillDto>);

        public IEnumerable<SkillDto> GetByCategory(int categoryId = 0)       
            => categoryId == 0
                ? _unitOfWork.Skills.GetAll()
                             .OrderBy(s => s.Name)
                             .Select(Mapper.Map<Skill, SkillDto>)
                : _unitOfWork.Skills.GetAll()
                             .Where(s => s.CategoryId == categoryId)
                             .OrderBy(s => s.Name)
                             .Select(Mapper.Map<Skill, SkillDto>);
        
        public SkillDto GetById(int id)
            => Mapper.Map<SkillDto>(_unitOfWork.Skills.GetById(id));

        public bool IsUnique(string name, int categoryId)
            => !_unitOfWork.Skills
                           .GetAll()
                           .Any(s => s.CategoryId == categoryId &&
                                     s.Name.ToLower() == name.ToLower());
    }
}
