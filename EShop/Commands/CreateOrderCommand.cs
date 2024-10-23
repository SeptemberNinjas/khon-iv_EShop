using Core;

namespace EShop.Commands;

/// <summary>
/// Команда создания заказа
/// </summary>
public class CreateOrderCommand(List<Order> orders, Cart cart)
{
    /// <summary>
    /// Наименование команды
    /// </summary>
    public const string Name = "CreateOrderCommand";
    
    /// <summary>
    /// Описание команды
    /// </summary>
    public const string Description = "создать заказ";
    
    /// <summary>
    /// Сгенерировать Id заказа
    /// </summary>
    private int GenerateOrderId() => orders.Count > 0 ? orders.Last().OrderId + 1 : 0;

    /// <summary>
    /// Выполнить команду
    /// </summary>
    public string Execute(string[]? args = null)
    {
        if (args is null || args.Length == 0)
        {
            if (cart.CartLines.Count == 0)
                return "Невозможно создать заказ: в корзине ничего нет.";
            
            orders.Add(new Order(GenerateOrderId(), cart));

            cart.CartLines = [];
            
            return "Заказ создан";
        }
        else
            return $"Некорректное число аргументов для команды {Name}";
    }
}