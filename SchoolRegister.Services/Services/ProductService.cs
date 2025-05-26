using System.Collections.Generic;
using System.Linq;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;

namespace SchoolRegister.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new(); // Tymczasowa pamięć

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void Update(Product product, int productId)
        {
            var existing = _products.FirstOrDefault(p => p.Id == productId);
            if (existing != null)
            {
                existing.Type = product.Type;
                existing.Model = product.Model;
                existing.Price = product.Price;
            }
        }

        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            return _products.Remove(product);
        }

        public Product Get(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                throw new InvalidOperationException($"Produkt o ID {id} nie istnieje.");
            return product;
        }

        public IList<Product> Get()
        {
            return _products.ToList();
        }
    }
}
