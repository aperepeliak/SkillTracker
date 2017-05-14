using System;
using System.Linq;
using System.Linq.Expressions;

namespace ST.DAL.Interfaces
{
    public interface IRepo<T>
    {
        void           Add      (T entity);
        void           Delete   (T entity);
        T              GetById  (int id);
        IQueryable<T>  GetAll   (Expression<Func<T, bool>> predicate = null);
        bool           IsExists (Func<T, bool> predicate);
    }
}
