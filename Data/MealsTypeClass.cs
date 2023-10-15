namespace Lab2.Data;

/// <summary>
/// Время приёма пищи
/// </summary>
public static class MealsTypeClass
{
    private const string Breakfast = "Завтрак";
    private const string Lunch = "Обед";
    private const string Supper = "Ужин";

    public static List<string> ToList() => new()
    {
        Breakfast, Lunch, Supper
    };
}