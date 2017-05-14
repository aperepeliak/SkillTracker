using ST.DAL.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ST.DAL.Interfaces
{
    public interface IDeveloperRepo
    {
        void      Create(Developer entity);
        Developer GetById(string id);
        Developer GetByEmail(string email);
        IQueryable<Developer> GetAll(Expression<Func<Developer, bool>> predicate = null);
    }
}
