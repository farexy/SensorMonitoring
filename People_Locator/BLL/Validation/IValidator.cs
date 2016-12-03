using BLL.Loader.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    internal interface IValidator<T> where T : BaseDTO
    {
        bool CanCreate(T Item);
        bool CanUpdate(T item);
        bool CanDelete(int id);
    }
}
