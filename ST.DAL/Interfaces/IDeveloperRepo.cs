using ST.DAL.Models;
using System.Collections.Generic;

namespace ST.DAL.Interfaces
{
    public interface IDeveloperRepo
    {
        void Create(Developer entity);
        Developer GetById(string id);
        IEnumerable<Developer> GetAll();
    }
}
