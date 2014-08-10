using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProductsApp.Client.ConsoleView.MessageHandlers;
using ProductsApp.Client.ConsoleView.Model;

namespace ProductsApp.Client.ConsoleView
{
    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = HttpClientFactory.Create(new ShowRequestHandler()))
            {
                client.BaseAddress = new Uri("http://Localhost:17223/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/products/1");

                if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync<Product>();
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }

                // HTTP POST
                var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                response = await client.PostAsJsonAsync("api/products", gizmo);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    Uri gizmoUrl = response.Headers.Location;
                    
                    // HTTP PUT
                    gizmo.Price = 80;   // Update price
                    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);
                    //Console.WriteLine("{0}\t${1}\t{2}", gizmo.Name, gizmo.Price, gizmo.Category);

                    
                    // HTTP DELETE
                    response = await client.DeleteAsync(gizmoUrl);
                    //Console.WriteLine(response);
                    
                }

            }

            Console.ReadLine();
        }
    }
}
