using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("SkillTrackerDb") { }

        public DbSet<Manager>   Managers { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}
