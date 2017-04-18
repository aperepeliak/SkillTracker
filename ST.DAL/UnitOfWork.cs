using ST.DAL.Interfaces;
using System.Threading.Tasks;
using ST.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL.Models;
using ST.DAL.Repos;
using System;

namespace ST.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;

        public ApplicationUserManager UserManager  { get; private set; }
        public ApplicationRoleManager RoleManager  { get; private set; }
        public IManagerRepo           Managers     { get; private set; }
        public IDeveloperRepo         Developers   { get; private set; }
        public IRepo<Skill>           Skills       { get; private set; }
        public IRepo<Category>        Categories   { get; private set; }
        public ISkillRatingRepo       SkillRatings { get; private set; }

        public UnitOfWork(ApplicationContext db)
        {
            _db = db;

            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));

            Managers     = new ManagerRepo    (_db);
            Developers   = new DeveloperRepo  (_db);
            Skills       = new SkillRepo      (_db);
            Categories   = new CategoryRepo   (_db);
            SkillRatings = new SkillRatingRepo(_db);
        }

        public void       Save()      =>       _db.SaveChanges();
        public async Task SaveAsync() => await _db.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                }
                disposed = true;
            }
        }
    }
}
