﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsApp.Domain.Entities;

namespace ProductsApp.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
            Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            item.Id = _nextId++;
            products.Add(item);
            var entityFromDatabase =  Get(item.Id);
            return entityFromDatabase;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
                return false;

            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}
