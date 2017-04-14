using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);
        IEnumerable<CategoryDto> GetAll();
    }
}
