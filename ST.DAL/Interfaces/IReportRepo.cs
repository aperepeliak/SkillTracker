using ST.DAL.Models;
using System.Collections.Generic;

namespace ST.DAL.Interfaces
{
    public interface IReportRepo
    {
        void Add(Report entity);
        void Delete(Report entity);
        void Get(int id);
        IEnumerable<Report> GetAll(string managerId);
    }
}
