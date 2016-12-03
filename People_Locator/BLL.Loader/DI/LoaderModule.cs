using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Configuration;
using BLL.Loader.HttpLoader;
using BLL.Loader;
using Autofac.Core;

namespace BLL.Loader.DI
{
    public class LoaderModule : Module
    {
        private string path;
        public LoaderModule(string config)
        {
            path = config;
        }
        protected override void Load(ContainerBuilder builder)
        {
            ConfigParser config = new ConfigParser(path);
            string url = config.Find("dal.baseAddress");

            builder.RegisterGeneric(typeof(HttpLoader<>)).As(typeof(ILoader<>)).WithParameter(new TypedParameter(typeof(string),url));
            base.Load(builder);
        }
    }
}
