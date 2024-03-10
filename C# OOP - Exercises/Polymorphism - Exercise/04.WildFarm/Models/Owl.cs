using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class Owl : Bird
    {
        private const double IncreaseWeight = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string Sound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Meat")
            {
                Weight += IncreaseWeight * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}