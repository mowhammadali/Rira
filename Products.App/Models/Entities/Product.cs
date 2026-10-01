using Products.App.Models.Enums;

namespace Products.App.Models.Entities;

public sealed class Product
{
    private Product(int id, string name, decimal price, Categories category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public int Id { get; private init; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public Categories Category { get; private set; }

    public static Product Create(int id, string name, decimal price, Categories category)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Product(id, name, price, category);
    }

    public override string ToString() => $"{Id} {Name} {Price} {Category.ToString()}";
}