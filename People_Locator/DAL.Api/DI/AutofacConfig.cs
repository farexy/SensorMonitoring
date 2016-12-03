using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using DAL.DI;
using System.Web.Mvc;

namespace DAL.Api.DI
{
    static class AutofacConfig
    {
        internal static void Config()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new DALModule());
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
