using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace DAL.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            GlobalConfiguration.Configuration.AddJsonpFormatter();

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var cors = new EnableCorsAttribute("http://localhost:5116,http://localhost:17995", "*", "*");
            config.EnableCors(cors);


        }
    }
}
