using ST.BLL.Interfaces;
using System.Linq;
using ST.BLL.DTOs;
using ST.DAL.Interfaces;
using System.Collections.Generic;

namespace ST.BLL.Services
{
    public class DeveloperService : IDeveloperService
    {
        IUnitOfWork _db;
        public DeveloperService(IUnitOfWork db)
        {
            _db = db;
        }

        public IEnumerable<SkillRatingDto> GetSkillRatingsById(string id)
        {
            return _db.Developers.GetById(id).SkillRatings.Select(s =>  new SkillRatingDto
            {
                
            })
        }
    }
}
