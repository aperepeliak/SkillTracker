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

        public ActionResult Index(int page = 1)
        {
            int numberOfItemsPerPage = 10;

            var usersViewModel = _userService.GetAll()
                            .Select(u => new UserViewModel
                            {
                                UserName = u.FullName,
                                Email = u.Email,
                                Role = u.Role
                            })
                            .ToPagedList(page, numberOfItemsPerPage);

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