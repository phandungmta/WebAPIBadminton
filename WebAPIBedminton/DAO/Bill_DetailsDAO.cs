using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.DTO;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class Bill_DetailsDAO
    {
        private BadmintonDBContext db;
        public Bill_DetailsDAO()
        {
            db = new BadmintonDBContext();
        }
        public Bill_DetailsDTO Take(int id)
        {
            var obj = db.Bill_Details.Find(id);
            return new Bill_DetailsDTO(obj);
        }
        public IEnumerable<Bill_DetailsDTO> List()
        {
            return db.Bill_Details.ToList().Select(x => new Bill_DetailsDTO(x));
        }
        public Bill_DetailsDTO Add(Bill_DetailsDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.Bill_Details.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new Bill_DetailsDTO(obj);
        }
        public bool Delete( long idProduct, long idBill)
        {
            var x = db.Bill_Details.Where( s => s.ProductID == idProduct && s.BillID == idBill).SingleOrDefault();
            if (x != null)
            {
                try
                {
                    db.Bill_Details.Remove(x);
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
        public bool isExist(long idProduct , long idBill)
        {
            return db.Bill_Details.Count(x => x.ProductID == idProduct && x.BillID == idBill) > 0;
        }
     


    }
}