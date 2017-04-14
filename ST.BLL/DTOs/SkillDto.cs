using System;

namespace ST.BLL.DTOs
{
    public class SkillDto
    {
        public int    Id           { get; set; }
        public string Name         { get; set; }
        public int    CategoryId   { get; set; }
        public string CategoryName { get; set; }

        public void Update(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
