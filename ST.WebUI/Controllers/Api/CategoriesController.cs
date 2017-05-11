using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IEnumerable<CategoryDto> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet]
        public IHttpActionResult ValidateUnique(string name)
        {
            return Ok(_categoryService.IsUnique(name));
        }
    }
}
