namespace _04.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; set; }
        int FoodEaten { get; set; }

        void Eat(IFood food);
    }
}