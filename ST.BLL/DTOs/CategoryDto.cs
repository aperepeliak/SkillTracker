﻿namespace ST.BLL.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
