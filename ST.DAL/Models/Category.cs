using System.Collections.Generic;

namespace ST.DAL.Models
{
    public class Category
    {
        public int    Id   { get; set; }
        public string Name { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public Category()
        {
            Skills = new List<Skill>();
        }
    }
}
