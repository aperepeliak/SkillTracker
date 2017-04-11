using ST.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace ST.DAL.EntityConfigs
{
    public class ManagerConfig : EntityTypeConfiguration<Manager>
    {
        public ManagerConfig()
        {
            HasRequired(m => m.User)
                .WithOptional(u => u.Manager)
                .WillCascadeOnDelete(true);
        }
    }
}
