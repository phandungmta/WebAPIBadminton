using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class ProductDAO
    {
        private BadmintonDBContext db;
        public ProductDAO()
        {
            db = new BadmintonDBContext();
        }
        public ProductDTO Take(int id)
        {
            var obj = db.Products.Find(id);
            return new ProductDTO(obj);
        }
        public IEnumerable<ProductDTO> List()
        {
            return db.Products.ToList().Select(x => new ProductDTO(x));
        }
        public ProductDTO Add(ProductDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.Products.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new ProductDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.Products.Find(id);
            if (x != null)
            {
                try
                {
                    db.Products.Remove(x);
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
            return db.Products.Count(x => x.ID == id) > 0;
        }
        public ProductDTO Update(ProductDTO x)
        {
            var a = db.Products.Find(x.ID);
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
                return new ProductDTO(a);
            }
            return null;
        }
    }
}