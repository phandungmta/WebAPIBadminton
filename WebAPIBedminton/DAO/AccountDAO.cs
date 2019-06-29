using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBedminton.DTO;
using WebAPIBedminton.Models;

namespace WebAPIBedminton.DAO
{
    public class AccountDAO
    {

        private BadmintonDBContext db;
        public AccountDAO()
        {
            db = new BadmintonDBContext();
        }
        public AccountDTO Take(int id)
        {
            var obj = db.Accounts.Find(id);
            return new AccountDTO(obj);
        }
        public IEnumerable<AccountDTO> List()
        {
            return db.Accounts.ToList().Select(x => new AccountDTO(x));
        }
        public AccountDTO Add(AccountDTO x)
        {
            var obj = x.toModel();
            try
            {
                db.Accounts.Add(obj);
                db.SaveChanges();
            }
            catch
            {
                return null;
            }
            return new AccountDTO(obj);
        }
        public bool Delete(int id)
        {
            var x = db.Accounts.Find(id);
            if (x != null)
            {
                try
                {
                    db.Accounts.Remove(x);
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
            return db.Accounts.Count(x => x.ID == id) > 0;
        }
        public AccountDTO Update(AccountDTO x)
        {
            var a = db.Accounts.Find(x.ID);
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
                return new AccountDTO(a);
            }
            return null;
        }

    }
}