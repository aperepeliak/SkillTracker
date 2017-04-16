using ST.DAL.Identity;
using ST.DAL.Models;
using System;
using System.Threading.Tasks;

namespace ST.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager  { get; }
        ApplicationRoleManager RoleManager  { get; }
        IManagerRepo           Managers     { get; }
        IDeveloperRepo         Developers   { get; }
        IRepo<Skill>           Skills       { get; }
        IRepo<Category>        Categories   { get; }
        ISkillRatingRepo       SkillRatings { get; }

        Task SaveAsync();
        void Save();
    }
}
