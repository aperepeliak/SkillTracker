namespace ST.BLL.DTOs
{
    public class SkillRatingDto
    {
        //public string DeveloperId { get; set; }
        public int    SkillId     { get; set; }

        public string SkillName   { get; set; }
        public string CategoryName { get; set; }

        public int    Rating      { get; set; }
    }
}
