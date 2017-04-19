using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface IDeveloperService
    {
        IDictionary<string, List<SkillRatingDto>> GetSkillRatings(string id);
        void AddSkillRating(SkillRatingDto dto);
        SkillRatingDto GetSkillRating(string developerId, int skillId);
        void Delete(SkillRatingDto dto);
        void UpdateSkillRating(string developerId, int skillId, int newRating);
    }
}
