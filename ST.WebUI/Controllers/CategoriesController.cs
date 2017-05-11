using ST.BLL.Infrastructure;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = SecurityRoles.Admin)]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var viewModel = _categoryService.GetAll()
                .Select(c => new CategoryViewModel {Id = c.Id, Name = c.Name })
                .ToList();

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new CategoryFormViewModel
            {
                Heading = "Add a category"
            };

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", viewModel);

            var category = new CategoryDto { Name = viewModel.Name };

            _categoryService.Add(category);

            return RedirectToAction("Index", "Categories");
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return HttpNotFound();

            var viewModel = new CategoryFormViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Heading = "Edit category"
            };

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", viewModel);

            var category = _categoryService.GetById(viewModel.Id);

            if (category == null)
                return HttpNotFound();

            category.Update(viewModel.Name);
            _categoryService.Update(category);

            return RedirectToAction("Index", "Categories");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return HttpNotFound();

            _categoryService.Remove(category);

            return RedirectToAction("Index", "Categories");
        }
    }
}