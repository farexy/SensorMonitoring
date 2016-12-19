using BLL.Loader;
using BLL.Loader.DTO;
using BLL.DI;
using Autofac;
using System;
using System.Collections.Generic;
using BLL.Validation;
using System.Linq;
using Newtonsoft.Json;

namespace BLL.Services
{
    abstract class BaseService<T> : IService<T> where T : BaseDTO
    {
        protected ILoader<T> loader = AutofacResolver.Container.Resolve<ILoader<T>>();
        protected IValidator<T> validator = AutofacResolver.Container.Resolve<IValidator<T>>();

        public void Create(T item)
        {
            if (!validator.CanCreate(item))
            {
                throw new ValidationException($"Cannot add to database next entity '{ JsonConvert.SerializeObject(item) }'");
            }

            CUDResponseView result = loader.PostItem(item);

            if (!result.IsSuccess)
            {
                throw new DALException("Cannot post item");
            }
        }

        //change
        public void Delete(object[] keys)
        {
            /*if (!validator.CanDelete((int)keys[0]))
            {
                throw new ValidationException("No entity with given id"); 
            }*/

            CUDResponseView result = loader.DeleteItem(keys);

            if (!result.IsSuccess)
            {
                //throw new DALException("Cannot delete item");
            }
        }

        public void Delete(int id)
        {
            if (!validator.CanDelete(id))
            {
                throw new ValidationException("No entity with given id");
            }

            CUDResponseView result = loader.DeleteItem(id);

            if (!result.IsSuccess)
            {
                throw new DALException("Cannot delete item");
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return loader.LoadAll().Where(predicate);
        }

        public void Update(T item)
        {
            if (!validator.CanUpdate(item))
            {
                throw new ValidationException($"Cannot add to database next entity '{ JsonConvert.SerializeObject(item) }'");
            }

            CUDResponseView result = loader.PutItem(item);

            if (!result.IsSuccess)
            {
                throw new DALException("Cannot put item");
            }
        }
    }
}
