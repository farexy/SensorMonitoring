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
    class SubscriptionValidator : Validator<SubscriptionDTO>
    {
        protected override bool existsItem(int id)
        {
            return true;
        }
        protected override bool existsItem(SubscriptionDTO item)
        {
            ILoader<SubscriptionDTO> loader = AutofacResolver.Container.Resolve<ILoader<SubscriptionDTO>>();
            return loader.LoadAll().Count(s => s.UserId == item.UserId && s.SensorId == item.SensorId) > 0;
        }

        protected override bool validateItemProperties(SubscriptionDTO item)
        {
            return true;
        }
    }
}
