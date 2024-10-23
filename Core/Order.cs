using System.Text;

namespace Core;

/// <summary>
/// Заказ
/// </summary>
public class Order(int orderId, Cart cart)
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int OrderId { get; } = orderId;
    
    /// <summary>
    /// Линия заказа
    /// </summary>
    public List<ItemLine> OrderLines { get; } = cart.CartLines;
    
    /// <summary>
    /// Статус оплаты заказа
    /// </summary>
    public OrderStatuses Status
    {
        get
        {
            if (PaymentAmount == 0)
                return OrderStatuses.NotPaid;
            else if (PaymentAmount == OrderTotalPrice)
                return OrderStatuses.Paid;
            else
                return OrderStatuses.PartiallyPaid;
        }
    }
    
    /// <summary>
    /// Итоговая стоимость заказа
    /// </summary>
    public decimal OrderTotalPrice => OrderLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();
    
    /// <summary>
    /// Сумма полученной оплаты по заказу
    /// </summary>
    public decimal PaymentAmount = 0;
    
    public Dictionary<PaymentTypes, decimal> PaymentList { get; private set;  } = new ();
    
    /// <summary>
    /// Добавить элемент в заказ
    /// </summary>
    public string AddItemToOrder(Nomenclature nomenclature, int count = 1)
    {
        var resultString = new StringBuilder($"Добавление в заказ {nomenclature.Name} в количестве {count}...{Environment.NewLine}");
        if (nomenclature.Type == NomenclatureTypes.Service)
            if (OrderLines.Select(line => line.Id).ToList().Contains(nomenclature.Id))
                return resultString.Append("Данная услуга уже добавлена в заказ").ToString();
            else
            {
                OrderLines.Add(new ItemLine(nomenclature, 1));
                return resultString.Append($"Услуга {nomenclature.Name} добавлена в заказ").ToString();
            }
        
        if (count < 1)
            return resultString.Append("Нельзя добавлять менее 1 товара").ToString();
        
        var catalogItemCount = Catalog.CatalogItems.First(i => i.Id == nomenclature.Id).Remains;
        if (catalogItemCount < 1)
            return resultString.Append("Товар закончился").ToString();
        
        count = catalogItemCount < count ? catalogItemCount : count;
        if (OrderLines.Select(x => x.Id).ToList().Contains(nomenclature.Id))
        {
            OrderLines.First(line => line.Id == nomenclature.Id).Count += count;
            Catalog.CatalogItems.First(catalogItem => catalogItem.Nomenclature.Id == nomenclature.Id).Remains -= count;
        }
        else
        {
            OrderLines.Add(new ItemLine(nomenclature, count));
            Catalog.CatalogItems.First(catalogItem => catalogItem.Nomenclature.Id == nomenclature.Id).Remains -= count;
        }

        return resultString.Append($"Товар {nomenclature.Name} добавлен в заказ в количестве {count}").ToString();
    }

    /// <summary>
    /// Оплатить заказ
    /// </summary>
    public string PayOrder(decimal amount, PaymentTypes paymentType)
    {
        decimal change = 0;
        
        if (OrderTotalPrice < amount + PaymentAmount)
        {
            change = amount + PaymentAmount - OrderTotalPrice;
            amount -= change;
        }
        
        if (!PaymentList.TryAdd(paymentType, amount))
            PaymentList[paymentType] += amount;
        
        PaymentAmount += amount;
        
        return PaymentAmount == OrderTotalPrice ? 
            $"Заказ полностью оплачен, сдача: {change}" : 
            $"Оплата принята, необходимо внести еще {OrderTotalPrice - PaymentAmount}";
    }
}