using System.Text.Json;

namespace Lab2.Data;

public class MenusClassRepositary
{
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    private readonly string _filepath = "wwwroot/sample-data/data.json";
    public List<MenusClass> MenusItems { get; set; } = new();

    public MenusClassRepositary()
    {
        var text = File.ReadAllText(_filepath);

        MenusItems = JsonSerializer.Deserialize<List<MenusClass>>(text!) ?? new();
    }
    /// <summary>
    /// Returns all items of the list
    /// </summary>
    /// <returns>List of data</returns>
    public IList<MenusClass> List()
    {
        lock (this)
        {
            // Deserialize data from file instead
            return MenusItems;
        }
    }

    /// <summary>
    /// Add new data row
    /// </summary>
    /// <param name="menus">New data row</param>
    public void Add(MenusClass menus)
    {
        lock (this)
        {
            menus.Id = Guid.NewGuid();

            MenusItems.Add(menus);
            WriteToFile();
        }
    }

    /// <summary>
    /// Update data row
    /// </summary>
    /// <param name="menus">Data row</param>
    public void Update(MenusClass menus)
    {
        lock (this)
        {
            var index = MenusItems.FindIndex(e => e.Id == menus.Id);
            if (index != -1)
                MenusItems[index] = menus;

            WriteToFile();
        }
    }

    /// <summary>
    /// Remove data row
    /// </summary>
    /// <param name="id">Row id to remove</param>
    public void Remove(Guid id)
    {
        lock (this)
        {
            var index = MenusItems.FirstOrDefault(e => e.Id == id);
            if (index == null)
                return;

            MenusItems.Remove(index);
            WriteToFile();
        }
    }

    private void WriteToFile()
    {
        File.WriteAllText(_filepath, JsonSerializer.Serialize(MenusItems, _options));
    }
}
