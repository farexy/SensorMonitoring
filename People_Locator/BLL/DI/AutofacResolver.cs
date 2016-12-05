using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BLL.Loader.DI;
using BLL.Validation;
using BLL.Loader.DTO;

namespace BLL.DI
{
    static class AutofacResolver
    {
        private static IContainer container;
        public static string ConfigPath { get;set;}

        public static IContainer Container
        {
            get
            {
                if (container == null)
                    container = buildContainer();

                return container;
            }
        }

        private static IContainer buildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new LoaderModule(ConfigPath));
            builder.RegisterType<UserValidator>().As<IValidator<UserDTO>>();
            builder.RegisterType<SensorValidator>().As<IValidator<SensorDTO>>();

            return builder.Build();
        }
    }
}
