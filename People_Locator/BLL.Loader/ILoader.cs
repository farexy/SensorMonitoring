using BLL.Loader.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Loader
{
    public interface ILoader<T> where T : class
    {
        IEnumerable<T> LoadAll();
        T LoadById(int id);
        CUDResponseView PostItem(T item);
        CUDResponseView PutItem(T item);
        CUDResponseView DeleteItem(int id);
    }
}
