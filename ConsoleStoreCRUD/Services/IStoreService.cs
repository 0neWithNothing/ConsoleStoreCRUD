using ConsoleStoreCRUD.Models;

namespace ConsoleStoreCRUD.Services
{
    public interface IStoreService
    {
        /// <summary>
        /// Добавление нового товара.
        /// </summary>
        /// <param name="productData">Объект класса <c>Product</c></param>
        public void AddProduct(Product productData);

        /// <summary>
        /// Получение списка всех товаров.
        /// </summary>
        /// <returns>Список товаров (Объектов класса <c>Product</c>)</returns>
        public List<Product> GetAllProducts();

        /// <summary>
        /// Получение конкретного товара по Id.
        /// </summary>
        /// <param name="id">Свойство Id типа Int, существующего объекта <c>Product</c></param>
        /// <returns>Объект товара или null, если товар не найден</returns>
        public Product? GetProductById(int id);

        /// <summary>
        /// Обновление конкретного товара.
        /// </summary>
        /// <param name="productData">Объект класса <c>Product</c></param>
        public void UpdateProduct(Product productData);

        /// <summary>
        /// Удаление конкретного товара по Id.
        /// </summary>
        /// <param name="id">Свойство Id типа Int, существующего объекта <c>Product</c></param>
        public void DeleteProduct(int id);
    }
}
