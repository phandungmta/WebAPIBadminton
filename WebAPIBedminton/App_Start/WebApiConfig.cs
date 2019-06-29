using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIBedminton
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Khong su dung dinh dang xml de su dung dinh dang json
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                      config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));

            config.Routes.MapHttpRoute(  
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
