using BusinessLayer.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ST.BLL.DTOs;
using ST.BLL.Interfaces;
using ST.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IUserService UserService 
            => HttpContext.GetOwinContext().GetUserManager<IUserService>();

        public IAuthenticationManager AuthenticationManager 
            => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var userDto = new UserDto
            {
                Email = viewModel.Email,
                Password = viewModel.Password
            };

            ClaimsIdentity claim = await UserService.Authenticate(userDto);

            if (claim == null)       
                ModelState.AddModelError("", "Invalid login or password");

            AuthenticationManager.SignOut();
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register (RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var userDto = new UserDto
            {
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = viewModel.Password,
                Role = viewModel.IsDeveloper 
                       ? SecurityRoles.Developer 
                       : SecurityRoles.Manager
            };

            OperationDetails operationDetails = await UserService.Create(userDto);

            if (operationDetails.Succedeed)
                return View("SuccessRegister");
            else
            {
                ModelState.AddModelError(operationDetails.Property,
                                         operationDetails.Message);

                return View(viewModel);
            }
                
        }
    }
}