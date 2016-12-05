using BLL.Loader.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IService<T> where T : BaseDTO
    {
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(object[] keys);
        void Delete(int id);
    }
}
