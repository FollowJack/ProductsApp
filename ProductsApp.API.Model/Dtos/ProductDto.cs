﻿using ProductsApp.Domain.Entities;

namespace ProductsApp.API.Model.Dtos
{
    public class ProductDto
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Constructors
        public ProductDto() { }
        public ProductDto(Product source)
        {
            UpdateModel(source);
        }
        #endregion

        #region Helpers
        private void UpdateModel(Product source)
        {
            Id = source.Id;
            Name = source.Name;
            Category = source.Category;
            Price = source.Price;
        }
        #endregion
    }
}
