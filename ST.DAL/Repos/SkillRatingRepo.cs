using System;
using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Linq;
using System.Data.Entity;

namespace ST.DAL.Repos
{
    public class SkillRatingRepo : ISkillRatingRepo
    {
        private ApplicationContext _db;
        public SkillRatingRepo(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(SkillRating entity)
        {
            _db.SkillRatings.Add(entity);
        }

        public void Delete(SkillRating entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }

        public SkillRating Get(string developerId, int skillId)
        {
            return _db.SkillRatings.SingleOrDefault(s => s.DeveloperId == developerId && 
                                                  s.SkillId == skillId);
        }
    }
}
