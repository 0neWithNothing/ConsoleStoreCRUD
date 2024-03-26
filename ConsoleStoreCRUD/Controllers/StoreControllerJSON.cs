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

        /// <inheritdoc />
        public void Add(Product productData)
        {
            var productInFile = _service.GetProductById(productData.Id);
            if (productInFile != null)
            {
                Console.WriteLine($"Товар с Id={productData.Id} уже существует!");
            }
            else
            {
                if (IsProductDataValid(productData))
                {
                    _service.AddProduct(productData);
                    Console.WriteLine($"Товар с Id={productData.Id} успешно добавлен");
                    return ;
                }
                Console.WriteLine($"Не валидные данные! Id и Price должны быть больше 0. Name обязательный параметр.");
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void Get(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine($"Товар с Id={id} не существует!");
                return ;
            }
            Console.WriteLine($"Id: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Description: {product.Description}");
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void Update(Product productData)
        {
            var productInFile = _service.GetProductById(productData.Id);
            if (productInFile == null)
            {
                Console.WriteLine($"Товар с Id={productData.Id} не существует!");
                return ;
            }
            if (IsProductDataValid(productData))
            {
                _service.UpdateProduct(productData);
                Console.WriteLine($"Товар с Id={productData.Id} успешно обновлен!");
                return ;
            }
            Console.WriteLine($"Не валидные данные! Id и Price должны быть больше 0. Name обязательный параметр.");
        }

        public bool IsProductDataValid(Product productData)
        {
            if (productData.Id <= 0) return false;

            if (productData.Price <= 0) return false;

            if (productData.Name.Length == 0) return false;

            return true;
        }
    }
}
