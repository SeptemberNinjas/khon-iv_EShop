using System;
using System.Linq;
using System.Text;
using Core;

namespace EShop.Commands;

/// <summary>
/// Команда отображения услуг
/// </summary>
public class DisplayServicesCommand
{
    private readonly List<CatalogItem> _services;
    
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "DisplayServicesCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "показать услуги";

    public DisplayServicesCommand(List<CatalogItem> services)
    {
        _services = services.Where(s => s is {Nomenclature.Price: > 0}).ToList();
    }
    
    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args)
    {
        int serviceCountForDisplay = 0;
        if (args is null || args.Length == 0)
            serviceCountForDisplay = _services.Count;
        else if (args.Length == 1)
            if (int.TryParse(args[0], out var number))
                serviceCountForDisplay = number;
            else
                return $"Для команды {Name} в качестве аргумента может быть только число - количество услуг";
        else return $"Некорректное число аргументов для команды {Name}";
        
        if ((serviceCountForDisplay < 1) || (serviceCountForDisplay > _services.Count))
            serviceCountForDisplay = _services.Count;

        var resultString = new StringBuilder();
        for (var i = 0; i < serviceCountForDisplay; i++)
        {
            resultString.Append($"{_services[i].Nomenclature.Name}{Environment.NewLine}" +
                            $"Цена: {_services[i].Nomenclature.Price}{Environment.NewLine}");
            if (_services[i].Nomenclature.Description != string.Empty)
                resultString.Append($"Описание: {_services[i].Nomenclature.Description}{Environment.NewLine}");
            if (i < serviceCountForDisplay - 1)
                resultString.Append($"{Environment.NewLine}");
        }
        
        return resultString.ToString();
    }
}