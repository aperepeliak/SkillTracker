﻿using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace ST.DAL.Repos
{
    public class SkillRatingRepo : ISkillRatingRepo
    {
        private readonly ApplicationContext _db;

        public SkillRatingRepo(ApplicationContext db)
        { _db = db; }

        public void Add(SkillRating entity)
            => _db.SkillRatings
                  .Add(entity);

        public void Delete(SkillRating entity)
            => _db.Entry(entity)
                  .State = EntityState.Deleted;

        public SkillRating Get(string developerId, int skillId)
            => _db.SkillRatings
                  .SingleOrDefault(s => s.DeveloperId == developerId &&
                                        s.SkillId     == skillId);

        public IEnumerable<SkillRating> GetForDeveloper(string developerId)
            => _db.SkillRatings
                  .Include(s => s.Skill)
                  .Include(s => s.Skill.Category)
                  .Where(s => s.DeveloperId == developerId);
    }
}
