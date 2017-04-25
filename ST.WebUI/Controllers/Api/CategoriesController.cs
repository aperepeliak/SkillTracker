using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ST.WebUI.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IEnumerable<CategoryDto> GetAll()
        {
            return _categoryService.GetAll();
        }
    }
}
