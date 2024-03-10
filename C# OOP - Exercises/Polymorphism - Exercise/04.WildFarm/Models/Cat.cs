using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class Cat : Feline
    {
        private const double IncreaseWeight = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string Sound()
        {
            return "Meow";
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
            {
                Weight += IncreaseWeight * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {nameof(food)}!");
            }
        }
    }
}