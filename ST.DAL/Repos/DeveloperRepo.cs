using ST.DAL.Interfaces;
using ST.DAL.Models;

namespace ST.DAL.Repos
{
    public class DeveloperRepo : IDeveloperRepo
    {
        private ApplicationContext _db;
        public DeveloperRepo(ApplicationContext db)
        {
            _db = db;
        }

        public void Create(Developer entity)
        {
            _db.Developers.Add(entity);
            _db.SaveChanges();
        }
    }
}
