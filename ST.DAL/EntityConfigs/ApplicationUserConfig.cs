using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
