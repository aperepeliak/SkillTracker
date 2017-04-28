using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface IDeveloperService
    {
        void AddSkillRating(string developerId, SkillRatingDto dto);
        SkillRatingDto GetSkillRating(string developerId, int skillId);
        void DeleteSkillRating(string developerId, int skillId);
        void UpdateSkillRating(string developerId, int skillId, int newRating);
        IEnumerable<DeveloperDto> SearchByTerm(string searchTerm);
        DeveloperDto GetDeveloper(string id);
        DeveloperDto GetDeveloperByEmail(string email);
        IEnumerable<DeveloperDto> SearchByFilters(IEnumerable<ReportFilterDto> filters);
        bool IsSkillRatingUnique(string developerId, int skillId);
    }
}
