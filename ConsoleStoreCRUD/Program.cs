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
            var productDataAdd = ReadProductData();
            if (productDataAdd != null)
            {
                controller.Add(productDataAdd);
            }
            break;
        case "getall":
            controller.GetAll();
            break;
        case "get":
            controller.Get(ReadProductId());
            break;
        case "update":
            var productDataUpdate = ReadProductData();
            if (productDataUpdate != null)
            {
                controller.Update(productDataUpdate);
            }
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

Product? ReadProductData()
{
    var productData = new Product();

    productData.Id = ReadProductId();
    if (!productData.IsIdValid())
    {
        Console.WriteLine("Id должен быть больше 0");
        return null;
    }

    
    Console.Write("Введите Name: ");
    productData.Name = Console.ReadLine() ?? "";
    if (!productData.IsNameValid())
    {
        Console.WriteLine("Name обязательный параметр!");
        return null;
    }

    Console.Write("Введите Price: ");
    if(!Double.TryParse(Console.ReadLine(), out var price))
    {
        Console.WriteLine("Price должен быть в формате double!");
        return null;
    }
    productData.Price = price;
    if (!productData.IsPriceValid())
    {
        Console.WriteLine("Price должен быть больше нуля!");
    }

    Console.Write("Введите Description: ");
    productData.Description = Console.ReadLine() ?? "";

    return productData;
}