using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductsApp.API.Webhost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web-API-Konfiguration und -Dienste
            var crossOriginRequests = new EnableCorsAttribute("http://localhost:13427", "*", "*");
            config.EnableCors(crossOriginRequests);

            // Web-API-Routen
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            TraceConfig.Register(config);
        }
    }
}
