using System.Text;

namespace Core;

/// <summary>
/// Корзина
/// </summary>
public class Cart
{
    /// <summary>
    /// Список линий корзины
    /// </summary>
    public List<ItemLine> CartLines { get; set; } = [];
    
    /// <summary>
    /// Итоговая стоимость корзины
    /// </summary>
    public decimal CartTotalPrice => CartLines.Select(line => line.ItemNomenclature.Price * line.Count).ToList().Sum();

    /// <summary>
    /// Добавить элемент в корзину
    /// </summary>
    public string AddItemToCart(Nomenclature nomenclature, int count = 1)
    {
        var resultString = new StringBuilder($"Добавление в корзину {nomenclature.Name} в количестве {count}...{Environment.NewLine}");
        if (nomenclature.Type == NomenclatureTypes.Service)
            if (CartLines.Select(line => line.Id).ToList().Contains(nomenclature.Id))
                return resultString.Append("Данная услуга уже добавлена в корзину").ToString();
            else
            {
                CartLines.Add(new ItemLine(nomenclature, 1));
                return resultString.Append($"Услуга {nomenclature.Name} добавлена в корзину").ToString();
            }
        
        if (count < 1)
            return resultString.Append("Нельзя добавлять менее 1 товара").ToString();
        
        var catalogItemCount = Catalog.CatalogItems.First(i => i.Id == nomenclature.Id).Remains;
        if (catalogItemCount < 1)
            return resultString.Append("Товар закончился").ToString();
        
        count = catalogItemCount < count ? catalogItemCount : count;
        if (CartLines.Select(x => x.Id).ToList().Contains(nomenclature.Id))
        {
            CartLines.First(line => line.Id == nomenclature.Id).Count += count;
            Catalog.CatalogItems.First(catalogItem => catalogItem.Nomenclature.Id == nomenclature.Id).Remains -= count;
        }
        else
        {
            CartLines.Add(new ItemLine(nomenclature, count));
            Catalog.CatalogItems.First(catalogItem => catalogItem.Nomenclature.Id == nomenclature.Id).Remains -= count;
        }

        return resultString.Append($"Товар {nomenclature.Name} добавлен в корзину в количестве {count}").ToString();
    }
}