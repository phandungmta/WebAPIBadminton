using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.DTO;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class BillDAO
    {
        private BadmintonDBContext db;
        public BillDAO()
        {
            db = new BadmintonDBContext();
        }
        public BillDTO Take(int id)
        {
            var obj = db.Bills.Find(id);
            return new BillDTO(obj);
        }
        public IEnumerable<BillDTO> List()
        {
            return db.Bills.ToList().Select(x => new BillDTO(x));
        }
        public BillDTO Add(BillDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.Bills.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new BillDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.Bills.Find(id);
            if (x != null)
            {
                try
                {
                    db.Bills.Remove(x);
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
            return db.Bills.Count(x => x.ID == id) > 0;
        }
        public BillDTO Update(BillDTO x)
        {
            var a = db.Bills.Find(x.ID);
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
                return new BillDTO(a);
            }
            return null;
        }
    }
}