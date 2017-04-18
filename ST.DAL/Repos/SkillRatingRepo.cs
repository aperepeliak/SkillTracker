using System;
using ST.DAL.Interfaces;
using ST.DAL.Models;

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
    }
}
