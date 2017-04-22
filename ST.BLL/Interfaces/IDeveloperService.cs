using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface IDeveloperService
    {
        void AddSkillRating(SkillRatingDto dto);
        SkillRatingDto GetSkillRating(string developerId, int skillId);
        void DeleteSkillRating(SkillRatingDto dto);
        void UpdateSkillRating(string developerId, int skillId, int newRating);
        IEnumerable<DeveloperDto> SearchByTerm(string searchTerm);
        DeveloperDto GetDeveloper(string id);
    }
}
