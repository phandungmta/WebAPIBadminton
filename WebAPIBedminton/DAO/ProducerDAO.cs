using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class ProducerDAO
    {
        private BadmintonDBContext  db;
        public ProducerDAO()
        {
            db = new BadmintonDBContext();
        }
        public ProducerDTO Take(int id)
        {
            var obj = db.Producers.Find(id);
            return new ProducerDTO(obj);
        }
        public IEnumerable<ProducerDTO> List()
        {
            return db.Producers.ToList().Select(x => new ProducerDTO(x));
        }
        public ProducerDTO Add(ProducerDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.Producers.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new ProducerDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.Producers.Find(id);
            if (x != null)
            {
                try
                {
                    db.Producers.Remove(x);
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
            return db.Producers.Count(x => x.ID == id) > 0;
        }
        public ProducerDTO Update(ProducerDTO x)
        {
            var a = db.Producers.Find(x.ID);
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
                return new ProducerDTO(a);
            }
            return null;
        }
    }
}