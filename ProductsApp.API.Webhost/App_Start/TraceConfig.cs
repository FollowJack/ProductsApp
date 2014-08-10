using System;
using System.Web.Http;
using System.Web.Http.Tracing;
using ProductsApp.API.Webhost.Tracing;

namespace ProductsApp.API.Webhost
{
    public static class TraceConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException("configuration");

            var traceWriter = new LogTraceWriter();

            config.Services.Replace(typeof(ITraceWriter), traceWriter);
        }
    }
}
