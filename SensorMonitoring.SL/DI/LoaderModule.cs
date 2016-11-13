using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SL.Loader;
using Autofac;
using System.Configuration;
using BLL.Loader.HttpLoader;

namespace SensorMonitoring.SL.DI
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

            builder.RegisterGeneric(typeof(HttpLoader<>)).As(typeof(ILoader<>)).WithParameter(new TypedParameter(typeof(string), url));
            base.Load(builder);
        }
    }
}