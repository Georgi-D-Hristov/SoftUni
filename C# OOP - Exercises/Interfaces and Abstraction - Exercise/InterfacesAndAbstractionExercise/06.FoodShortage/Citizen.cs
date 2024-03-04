namespace _06.FoodShortage;

public class Citizen : IBuyer
{
    private int _food;

    public Citizen(string name)
    {
        Name = name;
        _food = 0;
    }

    public string Name { get; init; }

    public void BuyFood()
    {
        _food += 10;
    }

    public int GetTotalFood()
    {
        return _food;
    }
}