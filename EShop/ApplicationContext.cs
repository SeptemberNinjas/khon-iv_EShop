using System;
using System.Collections.Generic;
using System.Windows.Input;
using Core;
using EShop.Commands;

namespace EShop;

/// <summary>
/// Контекст сеанса работы приложения
/// </summary>
public class ApplicationContext
{
    /// <summary>
    /// Заголовок
    /// </summary>
    public const string Title = "EShop";
    
    private readonly Cart _cart = new Cart();
    private readonly List<Order> _orders = [];
    
    /// <summary>
    /// Выполнить стартовую комманду
    /// </summary>
    public string ExecuteStartupCommand()
    {
        return ExecuteCommandByName(DisplayCommandsCommand.Name);
    }

    /// <summary>
    /// Выполнить команду по наименованию
    /// </summary>
    public string ExecuteCommandByName(string commandName, string[]? commandArgs = null)
    {
        var products = 
            Catalog.CatalogItems.Where(i => i.Nomenclature.Type == NomenclatureTypes.Product).ToList();
        var services = 
            Catalog.CatalogItems.Where(i => i.Nomenclature.Type == NomenclatureTypes.Service).ToList();
        
        return commandName switch
        {
            DisplayCommandsCommand.Name => DisplayCommandsCommand.Execute(commandArgs),
            ExitCommand.Name => ExitCommand.Execute(commandArgs),
            DisplayProductsCommand.Name => new DisplayProductsCommand(products).Execute(commandArgs),
            DisplayServicesCommand.Name => new DisplayServicesCommand(services).Execute(commandArgs),
            AddItemToCartCommand.Name => new AddItemToCartCommand(_cart).Execute(commandArgs),
            CreateOrderCommand.Name => new CreateOrderCommand(_orders, _cart).Execute(commandArgs),
            DisplayOrdersCommand.Name => new DisplayOrdersCommand(_orders).Execute(commandArgs),
            DisplayCartCommand.Name => new DisplayCartCommand(_cart).Execute(commandArgs),
            PaidOrderCommand.Name => new PaidOrderCommand(_orders).Execute(commandArgs),
            var _ => "Неизвестная команда (чтобы посмотреть все команды, введите DisplayCommands)"
        };
    }
}