using Microsoft.AspNet.Identity;
using ST.DAL.Models;

namespace ST.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base (store)
        {
        }
    }
}
