﻿using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;
using ST.DAL.Models;
using AutoMapper;
using System;

namespace ST.BLL.Services
{
    public class SkillService : ISkillService
    {
        ISkillsUnitOfWork _db;
        public SkillService(ISkillsUnitOfWork db)
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

        public IEnumerable<SkillDto> GetByCategory(int categoryId = 0)
        {

            return categoryId == 0

                ? _db.Skills.GetAll()
                            .OrderBy(s => s.Name)
                            .Select(Mapper.Map<Skill, SkillDto>)

                : _db.Skills.GetAll()
                            .Where(s => s.CategoryId == categoryId)
                            .OrderBy(s => s.Name)
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

        public bool IsUnique(string name, int categoryId)
        {
            return !_db.Skills
                    .GetAll()
                    .Any(s => s.CategoryId == categoryId && 
                              s.Name.ToLower() == name.ToLower());
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
