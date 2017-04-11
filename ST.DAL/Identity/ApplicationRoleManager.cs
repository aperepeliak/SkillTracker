using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL.Models;

namespace ST.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}
