using System;
using System.Collections.Generic;
using ST.DAL.Interfaces;
using ST.DAL.Models;

namespace ST.DAL.Repos
{
    public class ReportRepo : IReportRepo
    {
        private ApplicationContext _db;
        public ReportRepo(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(Report entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Report entity)
        {
            throw new NotImplementedException();
        }

        public void Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetAll(string managerId)
        {
            throw new NotImplementedException();
        }
    }
}
