using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class DeveloperConfig : EntityTypeConfiguration<Developer>
    {
        public DeveloperConfig()
        {
            HasRequired(d => d.User)
                .WithOptional(u => u.Developer)
                .WillCascadeOnDelete(true);
        }
    }
}
