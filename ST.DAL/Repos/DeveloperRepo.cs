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

        public IEnumerable<Developer> GetAll()
        {
            return _db.Developers
          //       .Include(d => d.SkillRatings)
          //       .Include(d => d.SkillRatings.Select(s => s.Skill))
                 .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                 .Include(d => d.User);
        }

        public Developer GetByEmail(string email)
        {
            return _db.Developers
         //       .Include(d => d.SkillRatings)
         //       .Include(d => d.SkillRatings.Select(s => s.Skill))
                .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                .Include(d => d.User)
                .SingleOrDefault(d => d.User.Email == email);
        }

        public Developer GetById(string id)
        {
            return _db.Developers
                .Include(d => d.SkillRatings)
                .Include(d => d.SkillRatings.Select(s => s.Skill))
                .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                .Include(d => d.User)
                .SingleOrDefault(d => d.DeveloperId == id);              
        }

        public IEnumerable<Developer> FilterBy(Expression<Func<Developer, bool>> predicate)
        {
            return _db.Developers
                //.Include(d => d.SkillRatings)
                //.Include(d => d.SkillRatings.Select(s => s.Skill))
                .Include(d => d.SkillRatings.Select(s => s.Skill.Category))
                .Include(d => d.User)
                .Where(predicate)
                .ToArray();
        }
    }
}
