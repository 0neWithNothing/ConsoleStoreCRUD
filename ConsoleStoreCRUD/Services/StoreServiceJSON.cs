using System.Text.Json;
using ConsoleStoreCRUD.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleStoreCRUD.Services
{
    public class StoreServiceJSON : IStoreService
    {
        private readonly string _fileName;

        public StoreServiceJSON(string fileName)
        {
            _fileName = fileName;

            if (!File.Exists(fileName))
            {
                var product1 = new Product() { Id = 1, Name = "T-shirt", Price = 1999.99 };
                var product2 = new Product() { Id = 2, Name = "Hoodie", Price = 5000.00 };
                var product3 = new Product() { Id = 3, Name = "Coat", Price = 10000.50 };

                // Добовляю заранье подготовленные данные, что-бы было с чем работать.
                AddProduct(product1);
                AddProduct(product2);
                AddProduct(product3);
            }
        }

        /// <inheritdoc />
        public void AddProduct(Product productData)
        {
            var productList = new ProductObject();
            if (File.Exists(_fileName))
            {
                productList.Data = GetAllProducts();
            }
            else
            {
                productList.Data = new List<Product>();
            }
            productList.Data.Add(productData);
            string jsonString = JsonSerializer.Serialize(productList);
            File.WriteAllText(_fileName, jsonString);
        }

        /// <inheritdoc />
        public List<Product> GetAllProducts()
        {
            string jsonString = File.ReadAllText(_fileName);
            var productsList = JsonSerializer.Deserialize<ProductObject>(jsonString) ?? new ProductObject();
            return productsList.Data;
        }

        /// <inheritdoc />
        public Product? GetProductById(int id)
        {
            var product = GetAllProducts().FirstOrDefault(p => p.Id == id);
            return product;
        }

        /// <inheritdoc />
        public void DeleteProduct(int id)
        {
            var productList = new ProductObject();
            productList.Data = GetAllProducts();
            var product = productList.Data.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                productList.Data.Remove(product);
                string jsonString = JsonSerializer.Serialize(productList);
                File.WriteAllText(_fileName, jsonString);
            }
        }

        /// <inheritdoc />
        public void UpdateProduct(Product productData)
        {
            var productList = new ProductObject();
            productList.Data = GetAllProducts();
            var product = productList.Data.FirstOrDefault(p => p.Id == productData.Id);
            if (product != null)
            {
                product.Name = productData.Name;
                product.Description = productData.Description;
                product.Price = productData.Price;
                string jsonString = JsonSerializer.Serialize(productList);
                File.WriteAllText(_fileName, jsonString);
            }
        }
    }
}
