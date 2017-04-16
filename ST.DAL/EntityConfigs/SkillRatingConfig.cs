using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class SkillRatingConfig : EntityTypeConfiguration<SkillRating>
    {
        public SkillRatingConfig()
        {
            Property(s => s.Rating)
                .IsRequired();

            HasKey(s => new { s.SkillId, s.DeveloperId });
        }
    }
}
