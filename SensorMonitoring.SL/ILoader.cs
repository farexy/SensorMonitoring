using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorMonitoring.SL.DTO;

namespace SL.Loader
{
    public interface ILoader<T> where T : class
    {
        IEnumerable<T> LoadAll();
        T LoadById(object[] keys);
        CUDResponseView PostItem(T item);
        CUDResponseView PutItem(T item);
        CUDResponseView DeleteItem(int id);
    }
}
