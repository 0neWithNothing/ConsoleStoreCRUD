using System.Text.Json;
using ConsoleStoreCRUD.Models;

namespace ConsoleStoreCRUD.Services
{
    public class StoreServiceJSON : IStoreService
    {
        private readonly string _fileName;

        public StoreServiceJSON(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Добавление нового товара.
        /// </summary>
        /// <param name="productData"></param>
        public void AddProduct(Product productData)
        {
            var productList = new ProductObject();
            if (File.Exists(_fileName))
            {
                productList.Data = GetAllProducts();
            }
            productList.Data.Add(productData);
            string jsonString = JsonSerializer.Serialize(productList);
            File.WriteAllText(_fileName, jsonString);
        }

        /// <summary>
        /// Получение списка всех товаров.
        /// </summary>
        /// <returns>Список объектов товаров</returns>
        public List<Product> GetAllProducts()
        {
            var jsonString = File.ReadAllText(_fileName);
            var productsList = JsonSerializer.Deserialize<ProductObject>(jsonString) ?? new ProductObject();
            return productsList.Data;
        }

        /// <summary>
        /// Получение конкретного товара по Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Объект товара или null</returns>
        public Product? GetProductById(int id)
        {
            var product = GetAllProducts().FirstOrDefault(p => p.Id == id);
            return product;
        }

        /// <summary>
        /// Удаление конкретного товара по Id.
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Обновление товара, если передан сущетвующий Id.
        /// </summary>
        /// <param name="productData"></param>
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

        /// <summary>
        /// Полная очистка хранилища (Файла).
        /// </summary>
        public void DeleteALlData()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }
    }
}
