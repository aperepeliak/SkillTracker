﻿using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Data.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ST.DAL.Repos
{
    public class SkillRepo : IRepo<Skill>
    {
        private readonly ApplicationContext _db;

        public SkillRepo(ApplicationContext db)
        { _db = db; }

        public void Add(Skill entity)
            => _db.Skills
                  .Add(entity);

        public void Delete(Skill entity)
            => _db.Entry(entity)
                  .State = EntityState.Deleted;

        public Skill GetById(int id) 
            => _db.Skills
                  .Find(id);

        public IQueryable<Skill> GetAll(Expression<Func<Skill, bool>> predicate = null)
           => predicate == null
                ? _db.Skills
                     .Include(s => s.Category)

                : _db.Skills
                     .Include(s => s.Category)
                     .Where(predicate);

        public bool IsExists(Func<Skill, bool> predicate)
            => _db.Skills
                  .Where(predicate)
                  .Any();
    }
}
