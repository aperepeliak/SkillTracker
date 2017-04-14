using System.ComponentModel.DataAnnotations;

namespace ST.DAL.Models
{
    public class SkillRating
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public int SkillId { get; set; }
        public string DeveloperId { get; set; }

        public Skill Skill { get; set; }
        public Developer Developer { get; set; }
    }
}
