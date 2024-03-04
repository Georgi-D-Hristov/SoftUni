namespace _06.FoodShortage;

public interface IBuyer
{
    string Name { get; init; }

    void BuyFood();

    int GetTotalFood();
}