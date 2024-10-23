namespace Core;

/// <summary>
/// Элемент каталога
/// </summary>
public class CatalogItem
{
    /// <summary>
    /// Идентификатор линии
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Номенклатура элемента каталога
    /// </summary>
    public Nomenclature Nomenclature { get; }

    /// <summary>
    /// Количесво остатков номенклатуры
    /// </summary>
    private int _remains;
    public int Remains
    {
        get => _remains;
        set
        {
            if ((Nomenclature.Type == NomenclatureTypes.Service) && (value != 1) || (value < 0))
                return;
            else
                _remains = value;
        }
    }

    public CatalogItem(Nomenclature nomenclature, int remains = 1)
    {
        Id = nomenclature.Id;
        Nomenclature = nomenclature;
        Remains = (nomenclature.Type == NomenclatureTypes.Service) ? 1 : remains;
    }
}