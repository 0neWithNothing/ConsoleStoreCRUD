using ConsoleStoreCRUD.Models;

namespace ConsoleStoreCRUD.Services
{
    public interface IStoreService
    {
        public void AddProduct(Product productData);
        public List<Product> GetAllProducts();
        public Product? GetProductById(int id);
        public void UpdateProduct(Product productData);
        public void DeleteProduct(int id);
    }
}
