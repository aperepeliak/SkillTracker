using ST.BLL.DTOs;
using System.Linq;

namespace ST.BLL.Interfaces
{
    public interface ISkillService
    {
        void Add    (SkillDto skillDto);
        void Update (SkillDto skillDto);
        void Remove (SkillDto skillDto);

        SkillDto GetById(int id);
        IQueryable<SkillDto> GetAll(int categoryId = 0);

        bool IsUnique(string name, int categoryId);
    }
}
