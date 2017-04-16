using System.Collections.Generic;
using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class SkillRepo : IRepo<Skill>
    {
        private ApplicationContext _db;
        public SkillRepo(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(Skill entity)      => _db.Skills.Add(entity);
        public void Delete(Skill entity)   => _db.Entry(entity).State = 
                                                  EntityState.Deleted;
        public Skill GetById(int id)       => _db.Skills.Find(id);
        public IEnumerable<Skill> GetAll() => _db.Skills.Include(s => s.Category);
    }
}
