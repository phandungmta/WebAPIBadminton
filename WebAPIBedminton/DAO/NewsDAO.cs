using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class NewsDAO
    {
        private BadmintonDBContext db;
        public NewsDAO()
        {
            db = new BadmintonDBContext();
        }
        public NewsDTO Take(int id)
        {
            var obj = db.News.Find(id);
            return new NewsDTO(obj);
        }
        public IEnumerable<NewsDTO> List()
        {
            return db.News.ToList().Select(x => new NewsDTO(x));
        }
        public NewsDTO Add(NewsDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.News.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new NewsDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.News.Find(id);
            if (x != null)
            {
                try
                {
                    db.News.Remove(x);
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
            return db.News.Count(x => x.ID == id) > 0;
        }
        public NewsDTO Update(NewsDTO x)
        {
            var a = db.News.Find(x.ID);
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
                return new NewsDTO(a);
            }
            return null;
        }
    }
}