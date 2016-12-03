using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.Loader
{
    public interface ILoader<T> where T : class
    {
        IEnumerable<T> LoadAll();
        T LoadById(int id);
        bool PostItem(T item);
        bool PutItem(T item);
        bool DeleteItem(int id);
    }
}
