using System;
using System.Linq;

namespace EShop.Commands;

/// <summary>
/// Команда отображения команд
/// </summary>
public static class DisplayCommandsCommand
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "DisplayCommands";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "показать все команды";

    /// <summary>
    /// Выполнить команду
    /// </summary>
    public static string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
        {
            var lines = new string[]
            {
                $"{DisplayCommandsCommand.Name} - {DisplayCommandsCommand.Description}",
                $"{DisplayProductsCommand.Name} - {DisplayProductsCommand.Description}",
                $"{DisplayServicesCommand.Name} - {DisplayServicesCommand.Description}",
                $"{DisplayCartCommand.Name} - {DisplayCartCommand.Description}",
                $"{AddItemToCartCommand.Name} - {AddItemToCartCommand.Description}",
                $"{CreateOrderCommand.Name} - {CreateOrderCommand.Description}",
                $"{DisplayOrdersCommand.Name} - {DisplayOrdersCommand.Description}",
                $"{PaidOrderCommand.Name} - {PaidOrderCommand.Description}",
                $"{ExitCommand.Name} - {ExitCommand.Description}",
            };
            
            return string.Join($"{Environment.NewLine}", lines);
        }
        else
            return $"Некорректное число аргументов для команды {Name}";
    }
}