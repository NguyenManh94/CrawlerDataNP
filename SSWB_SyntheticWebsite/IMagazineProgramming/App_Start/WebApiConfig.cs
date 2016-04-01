using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace IMagazineProgramming
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
            //    new MediaTypeWithQualityHeaderValue("text/html")
            //);

            /*Linecode first :D -- Router Data to JsonData*/
            config.Formatters.Remove(config.Formatters.XmlFormatter); /*remove định dạng XML => Json*/
            /*Format JsonAPI*/
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects; /*hỗ trợ thêm con số đầu dòng*/
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;/*Format code dễ nhìn*/
        }
    }
}
