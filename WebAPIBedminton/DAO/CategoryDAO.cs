using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.DTO;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class CategoryDAO
    {
        private BadmintonDBContext db;
        public CategoryDAO()
        {
            db = new BadmintonDBContext();
        }
        public CategoryDTO Take(int id)
        {
            var obj = db.Categories.Find(id);
            return new CategoryDTO(obj);
        }
        public IEnumerable<CategoryDTO> List()
        {
            return db.Categories.ToList().Select(x => new CategoryDTO(x));
        }
        public CategoryDTO Add(CategoryDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.Categories.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new CategoryDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.Categories.Find(id);
            if (x != null)
            {
                try
                {
                    db.Categories.Remove(x);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool isExist(long id)
        {
            return db.Categories.Count(x => x.ID == id) > 0;
        }
        public CategoryDTO Update(CategoryDTO x)
        {
            var a = db.Categories.Find(x.ID);
            if (a != null)
            {
                try
                {
                    a = x.toModel();
                    db.SaveChanges();
                }
                catch
                {
                    return null;
                }
                return new CategoryDTO(a);
            }
            return null;
        }
    }
}