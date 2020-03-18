using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace InventoryManagementSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //PC json serialization
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            //ends
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
