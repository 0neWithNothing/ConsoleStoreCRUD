using ConsoleStoreCRUD.Controllers;
using ConsoleStoreCRUD.Models;
using ConsoleStoreCRUD.Services;

var store = new StoreServiceJSON("Store.json");
IStoreController controller = new StoreControllerJSON(store);


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
    Console.WriteLine($"Id- {id}");
    return id;
}

Product ReadProductData()
{
    var productData = new Product();
    Console.Write("Введите Id: ");
    Int32.TryParse(Console.ReadLine(), out var id);
    productData.Id = id;
    Console.Write("Введите Name: ");
    productData.Name = Console.ReadLine() ?? "";
    Console.Write("Введите Price: ");
    Double.TryParse(Console.ReadLine(), out var price);
    productData.Price = price;
    Console.Write("Введите Description: ");
    productData.Description = Console.ReadLine() ?? "";
    return productData;
}