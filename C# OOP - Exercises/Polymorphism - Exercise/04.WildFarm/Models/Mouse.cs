using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class Mouse : Mammal
    {
        private const double IncreaseWeight = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Sound()
        {
            return "Squeak";
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
            {
                Weight += IncreaseWeight * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}