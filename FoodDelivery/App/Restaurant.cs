using FoodDelivery.Interfaces;

namespace FoodDelivery.App;

public class Restaurant : IElementContainer
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<MenuItem> _menuItems { get; set; }
    public string _address { get; set; }
    public string _email { get; set; }

    public Restaurant(string name, string description, string address, string email)
    {
        Name = name;
        Description = description;
        _menuItems = new List<MenuItem>();
        _address = address;
        _email = email;
    }

    public Restaurant(string name, string address, string email) : this(name, $"{name} {address}", address, email)
    {
        _menuItems = new List<MenuItem>();
    }

    public Restaurant(string name, string address) : this(name, $"{name} {address}", address, "No email given")
    {
        _menuItems = new List<MenuItem>();
    }

    public void Deconstruct(out string name, out string description)
    {
        name = Name;
        description = Description;
    }

    public void AddMenuItem(MenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public string GetFullDescription()
    {
        string menuItemsDescription = "";
        int index = 0;
        foreach (MenuItem item in _menuItems)
        {
            index++;
            if (index == _menuItems.Count())
                menuItemsDescription += $"{item.Name}.";
            else
                menuItemsDescription += $"{item.Name}, ";
        }

        return "Restaurant name: " + Name + "\n"
                + "Restaurant description: " + Description + "\n"
                + "Restaurant address: " + _address + "\n"
                + "Restaurant email: " + _email + "\n"
                + "Restaurant menu items: " + menuItemsDescription;
    }

    public IEnumerable<IElement> GetElementsByName(string name)
    {
        return _menuItems.Where(item => item.Name == name);
    }

    public IElement? GetElementByName(string name)
    {
        return GetElementsByName(name).FirstOrDefault();
    }

    public IEnumerable<IElement> GetAllElements()
    {
        return _menuItems;
    }

    public T? GetElementByType<T>() where T : IElement
    {
        return GetAllElements().OfType<T>().FirstOrDefault();
    }

    public IEnumerable<T> GetElementsByType<T>() where T : IElement
    {
        return GetAllElements().OfType<T>();
    }

    public override string ToString() =>
        $"{Name}";
}
