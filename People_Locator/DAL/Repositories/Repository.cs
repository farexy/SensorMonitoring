using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SensorMonitoring.Data.Models;

namespace DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : IModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Repository() {  }

        public void Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            T item = db.Set<T>().Find(id);

            if (item != null)
            {
                db.Set<T>().Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public void Update(T item)
        {
            object[] keys = item.Keys;
            db.Set<T>().Attach(item);

            db.Entry(item).State = EntityState.Modified;
        }

        public void SaveChanges() => this.db.SaveChanges();

    }
}
