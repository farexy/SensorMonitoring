using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL.DI;
using BLL.Loader;
using BLL.Loader.DTO;

namespace BLL.Validation
{
    class SensorReandingValidator : Validator<SensorReadingDTO>
    {
        protected override bool existsItem(int id)
        {
            return false;
        }
        protected override bool existsItem(SensorReadingDTO item)
        {
            ILoader<SensorReadingDTO> loader = AutofacResolver.Container.Resolve<ILoader<SensorReadingDTO>>();
            return loader.LoadAll().FirstOrDefault(sr => sr.DateTime == item.DateTime && sr.SensorId == item.SensorId) != null;
        }

        protected override bool validateItemProperties(SensorReadingDTO item)
        {
            if (item.SensorId <= 0)
            {
                return false;
            }



            return true;
        }
    }
}
