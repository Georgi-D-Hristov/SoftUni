using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    public class Hen : Bird
    {
        private const double IncreaseWeight = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string Sound()
        {
            return "Cluck";
        }

        public override void Eat(IFood food)
        {
            Weight += IncreaseWeight * food.Quantity;
            FoodEaten += food.Quantity;
        }
    }
}