﻿using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsApp.Client.ConsoleView.MessageHandlers
{
    public class LoggingHandler : DelegatingHandler
    {
        private StreamWriter _writer;

        public LoggingHandler(Stream stream)
        {
            _writer = new StreamWriter(stream);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if(!response.IsSuccessStatusCode)
                _writer.WriteLine("{0}\t{1}\t{2}",request.RequestUri, (int)response.StatusCode,response.Headers.Date);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                _writer.Dispose();
            base.Dispose(disposing);
        }
    }
}
