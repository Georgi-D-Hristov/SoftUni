namespace _03.ShoppingSpree;

using System.Collections.Generic;

public class Person
{
    private string _name;
    private decimal _money;
    private List<Product> _bag;

    public Person(string name, decimal money)
    {
        Name = name;
        Bag = new List<Product>();
        Money = money;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            _name = value;
        }
    }

    public List<Product> Bag
    {
        get { return _bag; }
        set { _bag = value; }
    }

    public decimal Money
    {
        get { return _money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            _money = value;
        }
    }

    public void BueProduct(Product product)
    {
        if (product.Cost > Money)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
        else
        {
            Console.WriteLine($"{Name} bought {product.Name}");
            Bag.Add(product);
            Money -= product.Cost;
        }
    }

    public override string ToString()
    {
        return $"{Name} - {String.Join(", ", Bag)}";
    }
}