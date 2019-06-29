using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class News_TypeDAO
    {
        private BadmintonDBContext db;
        public News_TypeDAO()
        {
            db = new BadmintonDBContext();
        }
        public News_TypeDTO Take(int id)
        {
            var obj = db.News_Type.Find(id);
            return new News_TypeDTO(obj);
        }
        public IEnumerable<News_TypeDTO> List()
        {
            return db.News_Type.ToList().Select(x => new News_TypeDTO(x));
        }
        public News_TypeDTO Add(News_TypeDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.News_Type.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new News_TypeDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.News_Type.Find(id);
            if (x != null)
            {
                try
                {
                    db.News_Type.Remove(x);
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
            return db.News_Type.Count(x => x.ID == id) > 0;
        }
        public News_TypeDTO Update(News_TypeDTO x)
        {
            var a = db.News_Type.Find(x.ID);
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
                return new News_TypeDTO(a);
            }
            return null;
        }
    }
}