using ST.DAL.Identity;
using System.Threading.Tasks;

namespace ST.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager  { get; }
        ApplicationRoleManager RoleManager  { get; }
        IManagerRepo           Managers     { get; }
        IDeveloperRepo         Developers   { get; }

        Task SaveAsync();
        void Save();
    }
}
