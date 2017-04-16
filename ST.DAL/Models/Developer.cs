using System.Collections.Generic;

namespace ST.DAL.Models
{
    public class Developer
    {
        public string DeveloperId { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<SkillRating> SkillRatings { get; set; }

        public Developer()
        {
            SkillRatings = new List<SkillRating>();
        }
    }
}
