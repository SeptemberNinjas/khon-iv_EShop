namespace Core;

/// <summary>
/// Линия корзины/заказа
/// </summary>
public class ItemLine
{
    public readonly Nomenclature ItemNomenclature;
    private int _count;
    
    /// <summary>
    /// Идентификатор линии
    /// </summary>
    public int Id => ItemNomenclature.Id;
    
    /// <summary>
    /// Количество элементов в линии корзины
    /// </summary>
    public int Count
    {
        get => _count;
        set
        {
            if (((ItemNomenclature.Type == NomenclatureTypes.Service) && (value > 1)) || value < 1)
                return;
            _count = value;
        }
    }
    
    public ItemLine(Nomenclature nomenclature, int count)
    {
        ItemNomenclature = nomenclature;
        Count = count;
    }
}