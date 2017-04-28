using ST.BLL.DTOs;
using System.Collections.Generic;

namespace ST.BLL.Interfaces
{
    public interface ISkillService
    {
        void Add    (SkillDto skillDto);
        void Update (SkillDto skillDto);
        void Remove (SkillDto skillDto);

        SkillDto GetById(int id);

        IEnumerable<SkillDto> GetAll();
        IEnumerable<SkillDto> GetByCategory(int categoryId = 0);
    }
}
