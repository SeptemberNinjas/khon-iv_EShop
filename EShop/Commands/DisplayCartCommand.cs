using Core;

namespace EShop.Commands;

/// <summary>
/// Команда отображения корзины
/// </summary>
public class DisplayCartCommand(Cart cart)
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "DisplayCartCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "показать корзину";

    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
        {
            if (cart.CartLines.Count == 0)
                return "Корзина пустая";
            
            return cart.CartLines.Aggregate("", (currentLine, nextLine) 
                => currentLine + ($"{nextLine.ItemNomenclature.Name} | {nextLine.Count} | " +
                                  $"{nextLine.ItemNomenclature.Price} | " +
                                  $"{nextLine.ItemNomenclature.Price * nextLine.Count}{Environment.NewLine}")) +
                   $"Сумма итого: {cart.CartTotalPrice}{Environment.NewLine}";
        }
        else 
            return $"Некорректное число аргументов для команды {Name}";
    }
    
}