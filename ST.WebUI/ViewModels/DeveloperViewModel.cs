using System.Collections.Generic;

namespace ST.WebUI.ViewModels
{
    public class DeveloperViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        IEnumerable<SkillRatingDto> SkillRatings { get; set; }
    }
}