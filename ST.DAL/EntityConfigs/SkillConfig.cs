using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class SkillConfig : EntityTypeConfiguration<Skill>
    {
        public SkillConfig()
        {
            Property(s => s.CategoryId)
                .IsRequired();

            Property(s => s.Name)
                .HasMaxLength(64);
        }
    }
}
