using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class ReportConfig : EntityTypeConfiguration<Report>
    {
        public ReportConfig()
        {
            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(120);

            Property(r => r.DateTime)
                .IsRequired();

            Property(r => r.ManagerId)
                .IsRequired();
        }
    }
}
