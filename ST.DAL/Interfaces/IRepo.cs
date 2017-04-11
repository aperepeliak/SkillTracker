using System.Collections.Generic;

namespace ST.DAL.Interfaces
{
    public interface IRepo<T>
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
