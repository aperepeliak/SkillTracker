using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace ST.DAL.Repos
{
    public class DeveloperRepo : IDeveloperRepo
    {
        private readonly ApplicationContext _db;

        public DeveloperRepo(ApplicationContext db)
        { _db = db; }

        public void Create(Developer entity)
           => _db.Developers.Add(entity);

        public IQueryable<Developer> GetAll()
           => _db.Developers
                 .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                 .Include(d => d.User);

        public Developer GetByEmail(string email)
           => _db.Developers
                 .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                 .Include(d => d.User)
                 .SingleOrDefault(d => d.User.Email == email);

        public Developer GetById(string id)
           => _db.Developers
                 .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                 .Include(d => d.User)
                 .SingleOrDefault(d => d.DeveloperId == id);

        public IEnumerable<Developer> FilterBy(Expression<Func<Developer, bool>> predicate)
           => _db.Developers
                 .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                 .Include(d => d.User)
                 .Where(predicate)
                 .ToList();
    }
}
