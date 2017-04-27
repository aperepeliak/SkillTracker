using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class ReportFilterConfig : EntityTypeConfiguration<ReportFilter>
    {
        public ReportFilterConfig()
        {
            Property(f => f.ReportId)
                .IsRequired();

            Property(f => f.SkillId)
                .IsRequired();

            Property(f => f.CategoryId)
                .IsRequired();

            Property(f => f.Rating)
                .IsRequired();

            Property(f => f.Comparer)
                .IsRequired();
        }
    }
}
