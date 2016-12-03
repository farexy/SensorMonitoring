using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using BLL.DI;

namespace BLL.Api.DI
{
    static class AutofacConfig
    {
        public static void Config(string path)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new BllModule(path));
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
