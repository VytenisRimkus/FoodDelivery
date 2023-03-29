using FoodDelivery.Interfaces;

namespace FoodDelivery.App;

public class MenuItem : IElement, IEquatable<MenuItem>
{
    public string Name { get; set; }

    public string Description => ToString();

    public decimal _price { get; set; }

    public MenuItem(string name, string description, decimal price)
    {
        Name = name;
        _price = price;
    }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        _price = price;
    }

    public override string ToString() =>
        $"Name: {Name}, Price: {_price}";

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var item = (MenuItem)obj;
        return Name == item.Name && _price == item._price;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, _price);
    }

    public bool Equals(MenuItem? other)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MenuItem item1, MenuItem item2)
    {
        if (item1 is null)
            return item2 is null;

        return item1.Equals(item2);
    }

    public static bool operator !=(MenuItem item1, MenuItem item2)
    {
        if (item1 == item2)
            return false;

        return true;
    }
}
