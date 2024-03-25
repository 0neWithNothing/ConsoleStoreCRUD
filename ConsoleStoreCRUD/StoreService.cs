using System.Text.Json;

namespace ConsoleStoreCRUD
{
    public class StoreService
    {
        readonly string _fileName;

        public StoreService(string fileName)
        {
            _fileName = fileName;
        }

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

        public List<Product> GetAllProducts()
        {
            var jsonString = File.ReadAllText(_fileName);
            var productsList = JsonSerializer.Deserialize<ProductObject>(jsonString) ?? new ProductObject();
            return productsList.Data;
        }

        public Product? GetProductById(int id)
        {
            var product = GetAllProducts().FirstOrDefault(p => p.Id == id);
            return product;
        }

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

        public void UpdateProduct(int id, Product productData)
        {
            var productList = new ProductObject();
            productList.Data = GetAllProducts();
            var product = productList.Data.FirstOrDefault(p => p.Id == id);
            if (product != null && product.Id == productData.Id)
            {
                product.Name = productData.Name;
                product.Description = productData.Description;
                product.Price = productData.Price;
                string jsonString = JsonSerializer.Serialize(productList);
                File.WriteAllText(_fileName, jsonString);
            }
        }

        public void DeleteALlData()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }
    }
}
