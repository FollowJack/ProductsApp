using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApp.API.Model.Dtos;
using ProductsApp.API.Webhost.Controllers;

namespace ProductsApp.Test.UnitTest.Controller
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void GetReturnsProduct()
        {
            // Arrange - create controller
            var controller = new ProductsController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act 
            var response = controller.GetProduct(2);
            // Assert 
            ProductDto product;
            Assert.IsTrue(response.TryGetContentValue<ProductDto>(out product));
        }
    }
}
