using ConsoleStoreCRUD.Models;

namespace ConsoleStoreCRUD.Controllers
{
    public interface IStoreController
    {
        public void Add(Product product);
        public void GetAll();
        public void Get(int id);
        public void Update(Product product);
        public void Delete(int id);
    }
}
