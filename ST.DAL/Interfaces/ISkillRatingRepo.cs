﻿using ST.DAL.Models;
using System.Collections.Generic;

namespace ST.DAL.Interfaces
{
    public interface ISkillRatingRepo
    {
        void Add(SkillRating entity);
        SkillRating Get(string developerId, int skillId);
        IEnumerable<SkillRating> GetForDeveloper(string developerId);
        void Delete(SkillRating entity);
    }
}
