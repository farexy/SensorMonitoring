using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitoring.Data.DAL
{

    public interface IRepository<T> where T : class
    {

        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T item);
        void Update(T item);
        bool Delete(object[] id);
        T Get(object[] keys);
        IEnumerable<T> Get();

        //void SaveChanges();
    }
}
