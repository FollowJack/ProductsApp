using ProductsApp.Domain.Entities;

namespace ProductsApp.API.Model.RequestModels
{
    public class ProductRequestModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Constructors
        public ProductRequestModel() { }
        #endregion

        #region Helpers
        public void UpdateSource(Product source)
        {
            source.Id = Id;
            source.Name = Name;
            source.Category = Category;
            source.Price = Price;
        }
        #endregion
    }
}
