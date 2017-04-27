namespace ST.DAL.Models
{
    public class ReportFilter
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int CategoryId { get; set; }
        public int SkillId { get; set; }
        public ComparerType Comparer { get; set; }
        public int Rating { get; set; }

        public Report Report { get; set; }
        public Category Category { get; set; }
        public Skill Skill { get; set; }
    }
}
