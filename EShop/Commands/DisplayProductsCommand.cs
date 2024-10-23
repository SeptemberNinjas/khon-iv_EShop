using System;
using System.Linq;
using System.Text;
using Core;

namespace EShop.Commands;

/// <summary>
/// Команда отображения товаров
/// </summary>
public class DisplayProductsCommand
{
    private readonly List<CatalogItem> _products;
    
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "DisplayProductsCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "показать товары";

    public DisplayProductsCommand(List<CatalogItem> products)
    {
        _products = products.Where(p => p is {Remains: > 0, Nomenclature.Price: > 0}).ToList();
    }
    
    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args)
    {
        var productCountForDisplay = 0;
        if (args is null || args.Length == 0)
            productCountForDisplay = _products.Count;
        else if (args.Length == 1)
            if (int.TryParse(args[0], out var number))
                productCountForDisplay = number;
            else
                return $"Для команды {Name} в качестве аргумента может быть только число - количество товаров";
        else return $"Некорректное число аргументов для команды {Name}";
        
        if ((productCountForDisplay < 1) || (productCountForDisplay > _products.Count))
            productCountForDisplay = _products.Count;
        
        var resultString = new StringBuilder();
        for (var i = 0; i < productCountForDisplay; i++)
        {
            resultString.Append($"{_products[i].Nomenclature.Name}{Environment.NewLine}" +
                   $"Цена: {_products[i].Nomenclature.Price}{Environment.NewLine}" +
                   $"Остаток: {_products[i].Remains}{Environment.NewLine}");
            if (_products[i].Nomenclature.Description != String.Empty)
                resultString.Append($"Описание: {_products[i].Nomenclature.Description}{Environment.NewLine}");
            if (i < productCountForDisplay - 1)
                resultString.Append($"{Environment.NewLine}");
        }
        
        return resultString.ToString();
    }
}