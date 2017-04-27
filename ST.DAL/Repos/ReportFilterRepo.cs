using ST.DAL.Interfaces;

namespace ST.DAL.Repos
{
    public class ReportFilterRepo : IReportFilterRepo
    {
        private ApplicationContext _db;
        public ReportFilterRepo(ApplicationContext db)
        {
            _db = db;
        }
    }
}
