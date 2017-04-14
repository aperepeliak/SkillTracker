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

            Property(s => s.SkillId)
                .IsRequired();

            Property(s => s.DeveloperId)
                .IsRequired();
        }
    }
}
