using ST.DAL.Interfaces;
using ST.DAL.Models;

namespace ST.DAL.Repos
{
    public class ManagerRepo : IManagerRepo
    {
        private ApplicationContext _db;
        public ManagerRepo(ApplicationContext db)
        {
            _db = db;
        }

        public void Create(Manager entity)
        {
            _db.Managers.Add(entity);
            _db.SaveChanges();
        }
    }
}
