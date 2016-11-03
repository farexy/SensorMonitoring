using SensorMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.DAL
{
    public class Repository<T> : IRepository<T> where T : IModel
    {

        protected ApplicationDbContext db = new ApplicationDbContext();
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public bool Delete(object[] keys)
        {
            T item = db.Set<T>().Find(keys);

            if (item != null)
            {
                db.Set<T>().Remove(item);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Get(object[] keys)
        {
            return db.Set<T>().Find(keys);
        }

        public IEnumerable<T> Get()
        {
            return db.Set<T>(); 
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public void Update(T item)
        {
            object[] keys = item.Keys;
            T current = db.Set<T>().Find(keys);
            current = item;
            db.SaveChanges();
            //db.Entry(current).State = EntityState.Modified;
        }
    }
}