using ST.DAL.Interfaces;
using System.Threading.Tasks;
using ST.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ST.DAL.Models;
using System;
using ST.DAL.Repos;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace ST.DAL
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly ApplicationContext _db;

        public ApplicationUserManager UserManager   { get; private set; }
        public ApplicationRoleManager RoleManager   { get; private set; }
        public IManagerRepo           Managers      { get; private set; }
        public IDeveloperRepo         Developers    { get; private set; }
        public ISkillRatingRepo       SkillRatings  { get; private set; }

        public UserUnitOfWork(ApplicationContext db)
        {
            _db = db;

            UserManager =  new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            RoleManager =  new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));

            Managers     = new ManagerRepo      (_db);
            Developers   = new DeveloperRepo    (_db);
            SkillRatings = new SkillRatingRepo  (_db);
        }

        public void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            catch(DbUpdateConcurrencyException ex)
            {
                // A database command did not affect the expected number of rows.
                // This usually indicates an optimistic concurrency violation; 
                // that is, a row has been changed in the database since it was queried.

                throw;
            }
            catch(DbUpdateException ex)
            {
                // An error occurred sending updates to the database

                throw;
            }
            catch(CommitFailedException ex)
            {
                // handle transaction failures here

                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task SaveAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // A database command did not affect the expected number of rows.
                // This usually indicates an optimistic concurrency violation; 
                // that is, a row has been changed in the database since it was queried.

                throw;
            }
            catch (DbUpdateException ex)
            {
                // An error occurred sending updates to the database

                throw;
            }
            catch (CommitFailedException ex)
            {
                // handle transaction failures here

                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public void       Save()      =>       _db.SaveChanges();
        //public async Task SaveAsync() => await _db.SaveChangesAsync();

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
