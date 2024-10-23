using Core;

namespace EShop.Commands;

/// <summary>
/// Команда добавления элемента в корзину
/// </summary>
public class AddItemToCartCommand(Cart cart)
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "AddItemToCartCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "добавить элемент в корзину";

    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
            return $"Для команды {Name} в качестве аргументов необходимо указать номенклатуру " +
                   $"и количество (если больше 1)";
        if (args.Length > 2)
            return $"Для команды {Name} необходимо указать не более 2 агрументов:" +
                   $" номенклатуру и количество (если больше 1)";
        if (!int.TryParse(args[0], out var itemId))
            return $"Для команды {Name} в качестве первого аргумента необходимо указать номенклатуру (число)";
        else if (args.Length == 2)
            if (!int.TryParse(args[1], out var count))
                return $"Для команды {Name} в качестве второго аргумента необходимо указать количество (число)";
            else return 
                Catalog.GetNomenclatureById(itemId) is null ? $"Номенклатура не найдена" : 
                    cart.AddItemToCart(Catalog.GetNomenclatureById(itemId)!, count);
        
        return 
            Catalog.GetNomenclatureById(itemId) is null ? $"Номенклатура не найдена" : 
                cart.AddItemToCart(Catalog.GetNomenclatureById(itemId)!);
    }
}