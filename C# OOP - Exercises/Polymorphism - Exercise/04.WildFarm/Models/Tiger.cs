using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class Tiger : Feline
    {
        private const double IncreaseWeight = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Sound()
        {
            return "ROAR!!!";
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