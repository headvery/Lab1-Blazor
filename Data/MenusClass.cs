namespace Lab2.Data;

/// <summary>
/// Меню на неделю
/// </summary>
public class MenusClass
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Название блюда
    /// </summary>
    public string DishName { get; set; } = string.Empty;
    /// <summary>
    /// День недели
    /// </summary>
    public string Day { get; set; } = string.Empty;
    /// <summary>
    /// Время приёма пищи
    /// </summary>
    public string MealTime { get; set; } = string.Empty;
}