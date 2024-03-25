using ConsoleStoreCRUD;

Product product1 = new Product() { Id = 1, Name = "T-shirt", Price = 1999.99 };
Product product2 = new Product() { Id = 2, Name = "Hoodie", Price = 5000.00 };
Product product3 = new Product() { Id = 3, Name = "Coat", Price = 10000.50 };

StoreService store = new StoreService("Store.json");

// Очищаю файл
store.DeleteALlData();

// Добовляю товары по одному
store.AddProduct(product1);
store.AddProduct(product2);
store.AddProduct(product3);

// Получаю все товары в виде списка, после чего перебираю список и вывожу в консоль
var getProducts = store.GetAllProducts();

foreach (var product in getProducts)
{
    Console.WriteLine(product.Id);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.Description);
}

Console.WriteLine("---------------------------------------");

// Получаю конкретный товар по Id и вывожу его данные в консоль
var getProductById  = store.GetProductById(1);

Console.WriteLine(getProductById?.Id);
Console.WriteLine(getProductById?.Name);
Console.WriteLine(getProductById?.Price);
Console.WriteLine(getProductById?.Description);

Console.WriteLine("---------------------------------------");

// Данные для обновления
Product productUpdate = new Product() { Id = 2, Name = "Hoodie", Price = 5000.00 , Description = "Good Hoodie"};

// Обновляю товар по Id, после чего получаю этот товар и вывожу его данные в консоль
store.UpdateProduct(2, productUpdate);

var getProductById2 = store.GetProductById(2);

Console.WriteLine(getProductById2?.Id);
Console.WriteLine(getProductById2?.Name);
Console.WriteLine(getProductById2?.Price);
Console.WriteLine(getProductById2?.Description);

Console.WriteLine("---------------------------------------");

// Удаляю товар, после чего получаю список всех товаров и вывожу их на консоль
store.DeleteProduct(3);

var getProducts2 = store.GetAllProducts();

foreach (var product in getProducts2)
{
    Console.WriteLine(product.Id);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.Description);
}