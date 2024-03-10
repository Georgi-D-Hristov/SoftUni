using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class Dog : Mammal
    {
        private const double IncreaseWeight = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Sound()
        {
            return "Woof!";
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

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}