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

            base.Load(builder);
        }
    }
}
