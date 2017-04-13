using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ST.BLL.Interfaces;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ST.WebUI.App_Start.Startup))]

namespace ST.WebUI.App_Start
{
    public class Startup
    {
        //IUserService _userService = DependencyResolver.Current.GetService<IUserService>();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(() => DependencyResolver.Current.GetService<IUserService>());
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        //private IUserService CreateUserService()
        //{
        //    return _userService;
        //}
    }
}