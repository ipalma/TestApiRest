using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestApiRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var settings = config.Formatters.JsonFormatter;
            settings.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            config.Formatters.Remove(config.Formatters.XmlFormatter);            

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
