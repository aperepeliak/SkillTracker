using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;
using ST.DAL.Models;
using AutoMapper;

namespace ST.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        ISkillsUnitOfWork _unitOfWork;

        public CategoryService(ISkillsUnitOfWork unitOfWork)
        { _unitOfWork = unitOfWork; }

        public void Add(CategoryDto dto)
        {
            _unitOfWork.Categories.Add(Mapper.Map<Category>(dto));
            _unitOfWork.Save();
        }

        public IEnumerable<CategoryDto> GetAll()
            => _unitOfWork.Categories
                          .GetAll()
                          .OrderBy(c => c.Name)
                          .Select(Mapper.Map<Category, CategoryDto>);

        public CategoryDto GetById(int id)
            => Mapper.Map<CategoryDto>(_unitOfWork.Categories.GetById(id));

        public bool IsUnique(string name)
            => !_unitOfWork.Categories
                           .GetAll()
                           .Any(c => c.Name.ToLower() == name.ToLower());
        
        public void Remove(CategoryDto categoryDto)
        {
            var category = _unitOfWork.Categories.GetById(categoryDto.Id);

            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
                _unitOfWork.Save();
            }
        }

        public void Update(CategoryDto categoryDto)
        {
            var category = _unitOfWork.Categories.GetById(categoryDto.Id);

            if (category != null)
            {
                category.Name = categoryDto.Name;
                _unitOfWork.Save();
            }
        }
    }
}
