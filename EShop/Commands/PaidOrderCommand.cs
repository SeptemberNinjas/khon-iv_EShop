using Core;

namespace EShop.Commands;

public class PaidOrderCommand(List<Order> orders)
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "PaidOrderCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "внести оплату по заказу";

    /// <summary>
    /// Выполнить команду Order order, decimal amount, PaymentTypes paymentType
    /// </summary>
    public string Execute(string[]? args)
    {
        if (args is null || args.Length != 3)
            return $"Для команды {Name} в качестве аргументов необходимо указать ID заказа, сумму и тип оплаты";

        if (!int.TryParse(args[0], out int orderId))
        {
            if (!orders.Select(order => order.OrderId).Contains(orderId))
                return "Заказ с указанным ID не найден";
            return $"Указан некорректный ID заказа";
        }

        if (!decimal.TryParse(args[1], out decimal amount))
            return $"Указана некорректная сумма";
        
        if (!Enum.TryParse(args[2], out PaymentTypes paymentType))
            return $"Указан некорректный тип оплаты";

        var order = orders.First(o => o.OrderId == orderId);
        return order.PayOrder(amount, paymentType);
    }
}