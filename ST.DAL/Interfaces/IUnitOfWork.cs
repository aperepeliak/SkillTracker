using ST.DAL.Identity;
using ST.DAL.Models;
using System.Threading.Tasks;

namespace ST.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager  { get; }
        ApplicationRoleManager RoleManager  { get; }
        IManagerRepo           Managers     { get; }
        IDeveloperRepo         Developers   { get; }
        IRepo<Skill>           Skills       { get; }
        IRepo<Category>        Categories   { get; }

        Task SaveAsync();
        void Save();
    }
}
