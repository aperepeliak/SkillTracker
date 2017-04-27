using ST.BLL.Interfaces;
using ST.BLL.DTOs;
using System;
using ST.DAL.Interfaces;
using ST.DAL.Models;

namespace ST.BLL.Services
{
    public class ManagerService : IManagerService
    {
        IUnitOfWork _db;
        public ManagerService(IUnitOfWork db)
        {
            _db = db;
        }
        public void SaveReport(string managerId, ReportDto dto)
        {
            _db.Reports.Add(new Report
            {

            });

            _db.Save();
        }
    }
}
