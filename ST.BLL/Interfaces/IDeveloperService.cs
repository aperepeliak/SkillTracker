using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface IDeveloperService
    {
        void AddSkillRating     (string developerId, SkillRatingDto dto);
        void DeleteSkillRating  (string developerId, int skillId);
        void UpdateSkillRating  (string developerId, int skillId, int newRating);

        SkillRatingDto GetSkillRating     (string developerId, int skillId);
        DeveloperDto   GetDeveloper       (string id);
        DeveloperDto   GetDeveloperByEmail(string email);

        IEnumerable<DeveloperDto> SearchByTerm(string searchTerm);
        IEnumerable<DeveloperDto> SearchByFilters(IEnumerable<ReportFilterDto> filters);

        bool IsSkillRatingUnique(string developerId, int skillId);
    }
}
