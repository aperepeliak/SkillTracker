using ST.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace ST.DAL.Interfaces
{
    public interface IUserUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IManagerRepo Managers { get; }
        IDeveloperRepo Developers { get; }
        ISkillRatingRepo SkillRatings { get; }

        Task SaveAsync();
        void Save();
    }
}
