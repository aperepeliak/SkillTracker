using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;
using ST.DAL.Models;

namespace ST.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork _db;
        public CategoryService(IUnitOfWork db)
        {
            _db = db;
        }

        public void Add(CategoryDto categoryDto)
        {
            _db.Categories.Add(new Category
            {
                Name = categoryDto.Name
            });

            _db.Save();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _db.Categories.GetAll()
                                 .Select(c => new CategoryDto
                                 {
                                     Id = c.Id,
                                     Name = c.Name
                                 });
        }

        public CategoryDto GetById(int id)
        {
            var category = _db.Categories.GetById(id);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
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
