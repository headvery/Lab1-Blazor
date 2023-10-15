namespace Lab2.Data;

/// <summary>
/// День недели
/// </summary>
public static class DaysClass
{
    private const string Monday = "Понедельник";
    private const string Tuesday = "Вторник";
    private const string Wednesday = "Среда";
    private const string Thursday = "Четверг";
    private const string Friday = "Пятница";
    private const string Saturday = "Суббота";
    private const string Sunday = "Воскресенье";

    public static List<string> ToList() => new()
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    };
}