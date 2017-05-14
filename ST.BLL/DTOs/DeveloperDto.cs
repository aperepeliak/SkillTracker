using System.Collections.Generic;

namespace ST.BLL.DTOs
{
    public class DeveloperDto
    {
        public string Email     { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }

        public IDictionary<string, List<SkillRatingDto>> SkillRatings { get; set; }

        public DeveloperDto()
        {
            SkillRatings = new Dictionary<string, List<SkillRatingDto>>();
        }
    }
}
