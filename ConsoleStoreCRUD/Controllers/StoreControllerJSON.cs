using ConsoleStoreCRUD.Models;
using ConsoleStoreCRUD.Services;

namespace ConsoleStoreCRUD.Controllers
{
    public class StoreControllerJSON : IStoreController
    {
        private readonly IStoreService _service;

        public StoreControllerJSON(IStoreService service)
        {
            _service = service;
        }

        /// <summary>
        /// Обработка запроса на добавление товара и вывод на консоль ответа.
        /// </summary>
        /// <param name="productData"></param>
        public void Add(Product productData)
        {
            var productInFile = _service.GetProductById(productData.Id);
            if (productInFile != null)
            {
                Console.WriteLine($"Товар с Id={productData.Id} уже существует!");
            } else
            {
                _service.AddProduct(productData);
                Console.WriteLine($"Товар с Id={productData.Id} успешно добавлен");
            }
        }

        /// <summary>
        /// Обработка запроса на удаление товара по Id и вывод на консоль ответа.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var product = _service.GetProductById(id);
            if (product != null)
            {
                _service.DeleteProduct(id);
                Console.WriteLine($"Товар с Id={id} успешно удален!");
            }
            else
            {
                Console.WriteLine($"Товар с Id={id} не существует!");
            }
        }

        /// <summary>
        /// Обработка запроса на получение товара по Id и вывод на консоль ответа.
        /// </summary>
        /// <param name="id"></param>
        public void Get(int id)
        {
            var product = _service.GetProductById(id);
            if (product != null)
            {
                Console.WriteLine($"Id: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Description: {product.Description}");
            }
            else
            {
                Console.WriteLine($"Товар с Id={id} не существует!");
            }
        }

        /// <summary>
        /// Обработка запроса на получение списка всех продуктов и вывод на консоль ответа.
        /// </summary>
        public void GetAll()
        {
            var products = _service.GetAllProducts();
            foreach ( var product in products )
            {
                Console.WriteLine($"Id: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine("--------------------------");
            }
        }

        /// <summary>
        /// Обработка запроса на обновление товара и вывод на консоль ответа.
        /// </summary>
        /// <param name="productData"></param>
        public void Update(Product productData)
        {
            var productInFile = _service.GetProductById(productData.Id);
            if (productInFile != null)
            {
                _service.UpdateProduct(productData);
                Console.WriteLine($"Товар с Id={productData.Id} успешно обновлен!");
            }
            else
            {
                Console.WriteLine($"Товар с Id={productData.Id} не существует!");
            }
        }
    }
}
