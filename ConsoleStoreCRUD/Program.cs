using ConsoleStoreCRUD.Controllers;
using ConsoleStoreCRUD.Models;
using ConsoleStoreCRUD.Services;

var product1 = new Product() { Id = 1, Name = "T-shirt", Price = 1999.99 };
var product2 = new Product() { Id = 2, Name = "Hoodie", Price = 5000.00 };
var product3 = new Product() { Id = 3, Name = "Coat", Price = 10000.50 };

var store = new StoreServiceJSON("Store.json");
IStoreController controller = new StoreControllerJSON(store);

// Очищаю файл.
store.DeleteALlData();

// Добовляю заранье подготовленные данные, что-бы было с чем работать.
store.AddProduct(product1);
store.AddProduct(product2);
store.AddProduct(product3);

// Цикл для обработки введеных команд.
string? commandTyped = "";
while (commandTyped?.ToLower() != "exit")
{
    Console.Write("Введите одну из команд - [Add, GetAll, Get, Update, Delete, Exit]: ");
    commandTyped = Console.ReadLine();
    switch (commandTyped?.ToLower())
    {
        case "add":
            controller.Add(ReadProductData());
            break;
        case "getall":
            controller.GetAll();
            break;
        case "get":
            controller.Get(ReadProductId());
            break;
        case "update":
            controller.Update(ReadProductData());
            break;
        case "delete":
            controller.Delete(ReadProductId());
            break;
    }
}

int ReadProductId()
{
    Console.Write("Введите Id товара: ");
    Int32.TryParse(Console.ReadLine(), out var id);
    return id;
}

Product ReadProductData()
{
    var productData = new Product();
    Console.Write("Введите Id: ");
    Int32.TryParse(Console.ReadLine(), out var id);
    productData.Id = id;
    Console.Write("Введите Name: ");
    productData.Name = Console.ReadLine();
    Console.Write("Введите Price: ");
    Double.TryParse(Console.ReadLine(), out var price);
    productData.Price = price;
    Console.Write("Введите Description: ");
    productData.Description = Console.ReadLine();
    return productData;
}