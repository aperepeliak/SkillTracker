namespace ST.BLL.DTOs
{
    public class ReportFilterDto
    {
        public int CategoryId { get; set; }
        public int SkillId { get; set; }
        public ComparerType Comparer { get; set; }
        public int Rating { get; set; }
    }

    public enum ComparerType
    {
        GreaterThan,
        LessThan,
        Equals
    }
}
