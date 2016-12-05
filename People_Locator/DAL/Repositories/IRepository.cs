using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T item);
        void Update(T item);
        bool Delete(object[] keys);
        bool Delete(int id);

        void SaveChanges();
    }
}
