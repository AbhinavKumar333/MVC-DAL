using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDAL
{
    public class CrudRepository
    {
        SampleDBEntities db;
        public CrudRepository()
        {
            db = new SampleDBEntities();
        }
        public bool Register(user u)
        {
            db.users.Add(u);
            int result = db.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public List<user> ViewAll()
        {
            List<user> result = db.users.ToList();
            return result;
        }
        public user View(int id)
        {
            user result = db.users.Find(id);
            return result;
        }
        public bool Update(user newu)
        {
            user oldu = View(newu.userId);
            oldu.userId = newu.userId;
            oldu.userName = newu.userName;
            oldu.Email = newu.Email;
            oldu.Phone = newu.Phone;
            oldu.Password = newu.Password;
            int result = db.SaveChanges();
            if (result > 0) { return true; }
            else { return false; }
        }
        public void Delete(int id)
        {
            user dal = db.users.Find(id);
            db.users.Remove(dal);
            db.SaveChanges();
        }
        public bool Login(string email,string password)
        {
            var result = (from c in db.users where c.Email == email && c.Password == password select c).ToList();
            if (result.Count > 0){  return true; }
            else { return false; }
        }
        public List<product> GetAllProducts()
        {
            return db.products.ToList();
        }
    }
}
