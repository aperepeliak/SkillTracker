using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL.EntityConfigs;
using ST.DAL.Models;
using System.Data.Entity;

namespace ST.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("SkillTrackerDb") { }

        public DbSet<Manager>      Managers      { get; set; }
        public DbSet<Developer>    Developers    { get; set; }
        public DbSet<Skill>        Skills        { get; set; }
        public DbSet<Category>     Categories    { get; set; }
        public DbSet<SkillRating>  SkillRatings  { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SkillConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new DeveloperConfig());
            modelBuilder.Configurations.Add(new ManagerConfig());
            modelBuilder.Configurations.Add(new SkillRatingConfig());

            base.OnModelCreating(modelBuilder);
        }
    } 
}
