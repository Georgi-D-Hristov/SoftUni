namespace _03.ShoppingSpree;

public class Product
{
    private string _name;
    private decimal _cost;

    public Product(string name, decimal cost)
    {
        Cost = cost;
        Name = name;
    }

    public decimal Cost
    {
        get { return _cost; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            _cost = value;
        }
    }

    public string Name
    {
        get { return _name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            _name = value;
        }
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}