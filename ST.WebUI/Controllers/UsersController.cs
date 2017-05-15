using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace ST.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index(int page = 1, int itemsPerPage = 5)
        {
            var usersViewModel = _userService.GetAll()
                            .Select(u => new UserViewModel
                            {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                Role = u.Role
                            })
                            .ToPagedList(page, itemsPerPage);

            return View(usersViewModel);
        }

        [HttpPost]
        public ActionResult Delete(string email)
        {
            var user = _userService.GetUserByEmail(email);

            if (user == null)
                return HttpNotFound();

            _userService.Delete(user);

            return RedirectToAction("Index", "Users");
        }
    }
}