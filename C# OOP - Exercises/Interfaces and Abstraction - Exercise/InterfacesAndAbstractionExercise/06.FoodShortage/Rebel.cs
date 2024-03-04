namespace _06.FoodShortage;

public class Rebel : IBuyer
{
    private int _food;

    public Rebel(string name)
    {
        Name = name;
        _food = 0;
    }

    public string Name { get; init; }

    public void BuyFood()
    {
        _food += 5;
    }

    public int GetTotalFood()
    {
        return _food;
    }
}