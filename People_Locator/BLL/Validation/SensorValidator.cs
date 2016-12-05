using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac;
using BLL.DI;
using BLL.Loader;
using BLL.Loader.DTO;

namespace BLL.Validation
{
    class SensorValidator : Validator<SensorDTO>
    {
        protected override bool existsItem(int id)
        {
            ILoader<SensorDTO> loader = AutofacResolver.Container.Resolve<ILoader<SensorDTO>>();
            return loader.LoadById(id) != null;
        }
        protected override bool existsItem(SensorDTO item)
        {
            return existsItem(item.Id);
        }

        protected override bool validateItemProperties(SensorDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrWhiteSpace(item.Substance)
                || string.IsNullOrWhiteSpace(item.Password) || string.IsNullOrWhiteSpace(item.Dimension))
            {
                return false;
            }

            

            return true;
        }
    }
}
