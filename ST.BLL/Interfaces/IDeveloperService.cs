using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface IDeveloperService
    {
        IEnumerable<SkillRatingDto> GetSkillRatingsById(string id);
    }
}
