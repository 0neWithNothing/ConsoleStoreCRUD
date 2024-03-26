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
    if (!Int32.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Не правильный формат Id!");
    }
    return id;
}

Product ReadProductData()
{
    var productData = new Product();

    productData.Id = ReadProductId();

    Console.Write("Введите Name: ");
    productData.Name = Console.ReadLine() ?? "";

    Console.Write("Введите Price: ");
    if(!Double.TryParse(Console.ReadLine(), out var price))
    {
        Console.WriteLine("Не правильный формат Price!");
    }
    productData.Price = price;

    Console.Write("Введите Description: ");
    productData.Description = Console.ReadLine() ?? "";

    return productData;
}