namespace Core;

/// <summary>
/// Номенклатура
/// </summary>
public class Nomenclature(
    int id,
    string name,
    decimal price,
    NomenclatureTypes nomenclatureType,
    string description = "")
{
    /// <summary>
    /// Идентификатор номенклатуры
    /// </summary>
    public int Id { get; } = id;
    /// <summary>
    /// Наименование номенклатуры
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// Стоимость номенклатуры
    /// </summary>
    public decimal Price { get; } = price;
    /// <summary>
    /// Тип номенклатуры
    /// </summary>
    public NomenclatureTypes Type { get; } = nomenclatureType;
    /// <summary>
    /// Описание номенклатуры
    /// </summary>
    public string Description { get; } = description;
}