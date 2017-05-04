using ST.DAL.Models;

namespace ST.DAL.Interfaces
{
    public interface ISkillsUnitOfWork
    {
        IRepo<Skill>    Skills     { get; }
        IRepo<Category> Categories { get; }
        
        void Save();
    }
}
