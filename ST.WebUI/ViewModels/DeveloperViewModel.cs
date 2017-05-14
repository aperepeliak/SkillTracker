using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class DeveloperViewModel
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }

        public IDictionary<string, List<SkillRatingDto>> SkillRatings { get; set; }

        public DeveloperViewModel()
        {
            SkillRatings = new Dictionary<string, List<SkillRatingDto>>();
        }
    }
}