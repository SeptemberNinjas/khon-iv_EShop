namespace Core;

/// <summary>
/// Каталог
/// </summary>
public static class Catalog
{
    /// <summary>
    /// Список элементов каталога
    /// </summary>
    public static readonly List<CatalogItem> CatalogItems = GetItems();

    /// <summary>
    /// Получить номенклатуру из каталога по id
    /// </summary>
    public static Nomenclature? GetNomenclatureById(int nomenclatureId) =>
        CatalogItems.Find(x => x.Id == nomenclatureId)?.Nomenclature;

    /// <summary>
    /// Получить элементы каталога
    /// </summary>
    private static List<CatalogItem> GetItems()
    {
        var items = new List<CatalogItem>
        {
            new CatalogItem(
                new Nomenclature(
                    0,
                    "Электрочайник BEON BN-006 синий",
                    450,
                    NomenclatureTypes.Product,
                    "Электрический чайник BEON BN-006 предназначен для кипячения воды. " +
                    "В модели открытая спираль. Функцию автоотключения прибор не имеет."
                    ),
                5
                ),
            new CatalogItem(
                new Nomenclature(
                    1,
                    "Фен Aceline BA-100 красный/черный",
                    599,
                    NomenclatureTypes.Product
                    ),
                7
                ),
            new CatalogItem(
                new Nomenclature(
                    2,
                    "6.7\" Смартфон realme Note 50 64 ГБ черный",
                    7499,
                    NomenclatureTypes.Product
                    ),
                10
                ),
            new CatalogItem(
                new Nomenclature(
                    3,
                    "24\" (61 см) LED-телевизор Aceline 24HEN1 черный",
                    1199,
                    NomenclatureTypes.Product
                    )
                ),
            new CatalogItem(
                new Nomenclature(
                    4,
                    "14.1\" Ноутбук DEXP Aquilon серебристый",
                    10000,
                    NomenclatureTypes.Product,
                    "Aquilon оборудован сенсорным NumPad, который упрощает ввод числовой информации. "
                    ),
                14
                ),
            new CatalogItem(
                new Nomenclature(
                    5,
                    "Установка встраиваемой посудомоечной машины",
                    3000,
                    NomenclatureTypes.Service,
                    "Подключение посудомоечной машины к водопроводу и канализации сложная работа"
                    )
                ),
            new CatalogItem(
                new Nomenclature(
                    6,
                    "Установка кондиционера (5000-11000 BTU) 3 метра",
                    11500,
                    NomenclatureTypes.Service,
                    "Установка кондиционера включает процедуру крепления внутреннего и внешнего блоков, " +
                    "подключения межблочных коммуникаций, наладку и пробный запуск климатического оборудования."
                    )
                ),
            new CatalogItem(
                new Nomenclature(
                    7,
                    "Сборка Игрового ПК",
                    3999,
                    NomenclatureTypes.Service,
                    "Наши специалисты могут собрать компьютер, который максимально соответствует " +
                    "вашим требованиям и сделают это быстро и качественно! "
                    )
                ),
            new CatalogItem(
                new Nomenclature(
                    8,
                    "Наклейка стекла на смартфон",
                    0,
                    NomenclatureTypes.Service,
                    "Мы предлагаем Вам услугу наклейки защитного стекла на устройство, " +
                             "гарантируя отсутствие дефектов."
                    )
                ),
            new CatalogItem(
                new Nomenclature(
                    9,
                    "Демонтаж и установка кондиционера (5000-11000 BTU)",
                    15300,
                    NomenclatureTypes.Service
                    )
                )
        };
        
        return items;
    }
}