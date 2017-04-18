using ST.DAL.Models;

namespace ST.DAL.Interfaces
{
    public interface ISkillRatingRepo
    {
        void Add(SkillRating entity);
        SkillRating Get(string developerId, int skillId);
        void Delete(SkillRating entity);
    }
}
