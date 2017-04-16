using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Data.Entity;
using System.Linq;

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

        public Developer GetById(string id)
        {
            return _db.Developers
                .Include(d => d.SkillRatings)
                .Include(d => d.User)
                .SingleOrDefault(d => d.DeveloperId == id);              
        }
    }
}
