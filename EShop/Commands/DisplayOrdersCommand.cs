using System.Text;
using Core;

namespace EShop.Commands;

/// <summary>
/// Команда отображения активных заказов
/// </summary>
public class DisplayOrdersCommand(List<Order> orders)
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "DisplayOrdersCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "показать активные заказы";

    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args)
    {
        if (args is null || args.Length == 0)
        {
            if (orders.Count == 0)
                return "Нет активных заказов";
            
            var resultString = new StringBuilder();
            var orderIndex = 1;
            foreach (var order in orders)
            {
                resultString.Append($"{Environment.NewLine}Заказ {orderIndex}{Environment.NewLine}" + 
                                order.OrderLines.Aggregate("", (currentLine, nextLine) => currentLine +
                                                            $"{nextLine.ItemNomenclature.Name} | {nextLine.Count} | " +
                                                            $"{nextLine.ItemNomenclature.Price} | " +
                                                            $"{nextLine.ItemNomenclature.Price * nextLine.Count}{Environment.NewLine}") +
                                $"Сумма итого: {order.OrderTotalPrice}{Environment.NewLine}" +
                                $"Оплачено: {order.PaymentAmount}{Environment.NewLine}");
                orderIndex++;
            }
            
            return resultString.ToString();
        }
        else 
            return $"Некорректное число аргументов для команды {Name}";
    }
}