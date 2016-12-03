using BLL.Loader.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
    abstract class Validator<T> : IValidator<T> where T: BaseDTO
    {
        public bool CanCreate(T item)
        {
            return !existsItem(item) && validateItemProperties(item);
        }

        public bool CanDelete(int id)
        {
            return existsItem(id);
        }

        public bool CanUpdate(T item)
        {
            return existsItem(item) && validateItemProperties(item);
        }

        protected abstract bool existsItem(T item);
        protected abstract bool existsItem(int id);
        protected abstract bool validateItemProperties(T item);
    }
}
