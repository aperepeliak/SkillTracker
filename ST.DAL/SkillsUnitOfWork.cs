using ST.DAL.Interfaces;
using ST.DAL.Models;
using ST.DAL.Repos;

namespace ST.DAL
{
    public class SkillsUnitOfWork : ISkillsUnitOfWork
    {
        private readonly ApplicationContext _db;
      
        public IRepo<Skill>    Skills     { get; private set; }
        public IRepo<Category> Categories { get; private set; }
       
        public SkillsUnitOfWork(ApplicationContext db)
        {
            _db = db;
         
            Skills     = new SkillRepo    (_db);
            Categories = new CategoryRepo (_db);        
        }

        public void Save() => _db.SaveChanges();
    }
}
