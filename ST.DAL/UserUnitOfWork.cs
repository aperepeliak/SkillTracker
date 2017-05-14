using ST.DAL.Interfaces;
using System.Threading.Tasks;
using ST.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL.Models;
using System;
using ST.DAL.Repos;

namespace ST.DAL
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly ApplicationContext _db;

        public ApplicationUserManager UserManager   { get; }
        public ApplicationRoleManager RoleManager   { get; }
        public IManagerRepo           Managers      { get; }
        public IDeveloperRepo         Developers    { get; }
        public ISkillRatingRepo       SkillRatings  { get; }

        public UserUnitOfWork(ApplicationContext db)
        {
            _db = db;

            UserManager =  new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            RoleManager =  new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));

            Managers     = new ManagerRepo      (_db);
            Developers   = new DeveloperRepo    (_db);
            SkillRatings = new SkillRatingRepo  (_db);
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
                    _db.Dispose();
                    UserManager.Dispose();
                    RoleManager.Dispose();
                }
                disposed = true;
            }
        }
    }
}
