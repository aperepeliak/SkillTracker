using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;
using ST.DAL.Models;
using AutoMapper;
using System;

namespace ST.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        ISkillsUnitOfWork _db;
        public CategoryService(ISkillsUnitOfWork db)
        {
            _db = db;
        }

        public void Add(CategoryDto dto)
        {
            _db.Categories.Add(Mapper.Map<Category>(dto));
            _db.Save();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _db.Categories
                      .GetAll()
                      .OrderBy(c => c.Name)
                      .Select(Mapper.Map<Category, CategoryDto>);
        }

        public CategoryDto GetById(int id)
        {
            var category = _db.Categories.GetById(id);
            return Mapper.Map<CategoryDto>(category);
        }

        public bool IsUnique(string name)
        {
            return !_db.Categories
                        .GetAll()
                        .Any(c => c.Name.ToLower() == name.ToLower());
        }

        public void Remove(CategoryDto categoryDto)
        {
            var category = _db.Categories.GetById(categoryDto.Id);

            if (category != null)
            {
                _db.Categories.Delete(category);
                _db.Save();
            }
        }

        public void Update(CategoryDto categoryDto)
        {
            var category = _db.Categories.GetById(categoryDto.Id);

            if (category != null)
            {
                category.Name = categoryDto.Name;
                _db.Save();
            }
        }
    }
}
