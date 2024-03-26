using ConsoleStoreCRUD.Models;

namespace ConsoleStoreCRUD.Controllers
{
    public interface IStoreController
    {
        /// <summary>
        /// Обработка запроса на добавление товара и вывод на консоль ответа.
        /// </summary>
        /// <param name="productData"></param>
        public void Add(Product product);

        /// <summary>
        /// Обработка запроса на получение списка всех товаров и вывод на консоль ответа.
        /// </summary>
        public void GetAll();

        /// <summary>
        /// Обработка запроса на получение товара по Id и вывод на консоль ответа.
        /// </summary>
        /// <param name="id"></param>
        public void Get(int id);

        /// <summary>
        /// Обработка запроса на обновление товара и вывод на консоль ответа.
        /// </summary>
        /// <param name="productData"></param>
        public void Update(Product product);

        /// <summary>
        /// Обработка запроса на удаление товара по Id и вывод на консоль ответа.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
