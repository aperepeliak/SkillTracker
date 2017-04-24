using ST.DAL.Models;
using System.Collections.Generic;

namespace ST.DAL.Interfaces
{
    public interface IDeveloperRepo
    {
        void Create(Developer entity);
        Developer GetById(string id);
        Developer GetByEmail(string email);
        IEnumerable<Developer> GetAll();
    }
}
