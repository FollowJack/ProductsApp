using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsApp.Client.ConsoleView.MessageHandlers
{
    public class ShowRequestHandler : DelegatingHandler
    {
        public ShowRequestHandler() { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            //if (!response.IsSuccessStatusCode)
                Console.WriteLine("{0}\t{1}\t{2}", request.RequestUri, (int)response.StatusCode, response.Headers.Date);

            return response;
        }
    }
}
