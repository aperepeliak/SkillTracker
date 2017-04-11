using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            Property(c => c.Name)
                .HasMaxLength(64);
        }
    }
}
