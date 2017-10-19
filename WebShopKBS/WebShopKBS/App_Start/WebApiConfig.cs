using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebShopKBS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
			var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;	
	        json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
	        config.Formatters.JsonFormatter
		        .SerializerSettings
		        .ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
