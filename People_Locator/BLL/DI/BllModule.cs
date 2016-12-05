using Autofac;
using BLL.Services;
using BLL.Loader.DTO;

namespace BLL.DI
{
    public class BllModule : Module
    {
        public BllModule(string path)
        {
            AutofacResolver.ConfigPath = path;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IService<>));

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserService>().As<IService<UserDTO>>();

            builder.RegisterType<SubscriptionService>().As<IService<SubscriptionDTO>>();

            builder.RegisterType<SensorService>().As<IService<SensorDTO>>();

            builder.RegisterType<SensorReadingService>().As<IService<SensorReadingDTO>>();

            base.Load(builder);
        }
    }
}
