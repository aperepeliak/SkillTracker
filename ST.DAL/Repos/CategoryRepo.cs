using System.Collections.Generic;
using ST.DAL.Interfaces;
using ST.DAL.Models;
using System.Data.Entity;
using System;
using System.Linq;

namespace ST.DAL.Repos
{
    public class CategoryRepo : IRepo<Category>
    {
        private readonly ApplicationContext _db;

        public CategoryRepo(ApplicationContext db)
        { _db = db; }

        public void Add(Category entity)      
            => _db.Categories.Add(entity);

        public void Delete(Category entity)   
            => _db.Entry(entity).State = EntityState.Deleted;

        public Category GetById(int id)       
            => _db.Categories.Find(id);

        public IEnumerable<Category> GetAll() 
            => _db.Categories;

        public bool IsExists(Func<Category, bool> predicate)
            => _db.Categories.Where(predicate).Any();           
    }
}
