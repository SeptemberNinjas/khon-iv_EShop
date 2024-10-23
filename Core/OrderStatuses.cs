namespace Core;

public enum OrderStatuses
{
    /// <summary>
    /// Не оплачен
    /// </summary>
    NotPaid = 0,
    
    /// <summary>
    /// Частично оплачен
    /// </summary>
    PartiallyPaid,
    
    /// <summary>
    /// Полностью оплачен
    /// </summary>
    Paid
}