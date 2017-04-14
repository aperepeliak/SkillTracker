using Microsoft.AspNet.Identity.EntityFramework;

namespace ST.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Developer Developer { get; set; }
        public Manager Manager { get; set; }
    }  
}
