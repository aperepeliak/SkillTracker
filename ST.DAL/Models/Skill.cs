using System.Collections.Generic;

namespace ST.DAL.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<SkillRating> SkillRatings { get; set; }

        public Skill()
        {
            SkillRatings = new List<SkillRating>();
        }
    }
}
