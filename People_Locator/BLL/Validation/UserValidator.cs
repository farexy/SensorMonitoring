using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Loader.DTO;
using BLL.Loader;
using BLL.DI;
using Autofac;
using System.Text.RegularExpressions;

namespace BLL.Validation
{
    internal class UserValidator : Validator<UserDTO>
    {
        protected override bool existsItem(int id)
        {
            ILoader<UserDTO> loader = AutofacResolver.Container.Resolve<ILoader<UserDTO>>();
            return loader.LoadById(id) != null;
        }
        protected override bool existsItem(UserDTO item)
        {
            return existsItem(item.Id);
        }

        protected override bool validateItemProperties(UserDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Email) ||  string.IsNullOrWhiteSpace(item.Email) || string.IsNullOrWhiteSpace(item.Password))
            {
                return false;
            }

            // check email
            Regex exp = new Regex(@"\w+@\w+\.\w+");

            if (!exp.IsMatch(item.Email))
            {
                return false;
            }

            return true;
        }
    }
}
