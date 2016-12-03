using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using BLL.Loader.DI;
using System.Web.Mvc;

namespace SL.DI
{
    static class AutofacResolver
    {
        public static void Config(string path)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new LoaderModule(path));
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
