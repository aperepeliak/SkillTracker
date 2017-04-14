using System.Collections.Generic;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.DAL.Interfaces;
using System.Linq;

namespace ST.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork _db;
        public CategoryService(IUnitOfWork db)
        {
            _db = db;
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
                Id   = category.Id,
                Name = category.Name
            };
        }
    }
}
