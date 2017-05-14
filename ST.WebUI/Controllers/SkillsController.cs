using ST.BLL.Infrastructure;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = SecurityRoles.Admin)]
    public class SkillsController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly ICategoryService _categoryService;

        public SkillsController(ISkillService skillService, 
                                ICategoryService categoryService)
        {
            _skillService    = skillService;
            _categoryService = categoryService;
        }

        public ActionResult Skills(int categoryId = 0, int page = 1)
        {
            int numberOfItemsPerPage = 8;

            var viewModel = new SkillsViewModel
            {
                Skills = _skillService.GetByCategory(categoryId)
                                      .ToPagedList(page, numberOfItemsPerPage),

                Categories           = _categoryService.GetAll().ToList(),
                SelectedCategoryId   = categoryId,
                SelectedCategoryName = categoryId == 0
                                        ? "Filter By Category"
                                        : _categoryService.GetById(categoryId)
                                                          .Name
            };

            return View(viewModel);
        }

        public ActionResult Index() => RedirectToAction("Skills");

        public ActionResult Create()
        {
            var viewModel = new SkillFormViewModel
            {
                Categories = _categoryService.GetAll(),
                Heading = "Add a skill"
            };
            return View("SkillForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _categoryService.GetAll();
                return View("SkillForm", viewModel);
            }

            var skill = new SkillDto
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId
            };

            _skillService.Add(skill);

            return RedirectToAction("Skills", "Skills");
        }

        public ActionResult Edit(int id)
        {
            var skill = _skillService.GetById(id);

            if (skill == null)
                return HttpNotFound();

            var viewModel = new SkillFormViewModel
            {
                Id = id,
                Name = skill.Name,
                CategoryId = skill.CategoryId,
                Categories = _categoryService.GetAll(),
                Heading = "Edit a skill"
            };

            return View("SkillForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SkillFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _categoryService.GetAll();
                return View("SkillForm", viewModel);
            }

            var skill = _skillService.GetById(viewModel.Id);

            if (skill == null)
                return HttpNotFound();

            skill.Update(viewModel.Name, viewModel.CategoryId);
            _skillService.Update(skill);

            return RedirectToAction("Skills", "Skills");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var skill = _skillService.GetById(id);

            if (skill == null)
                return HttpNotFound();

            _skillService.Remove(skill);

            return RedirectToAction("Skills", "Skills");
        }
    }
}