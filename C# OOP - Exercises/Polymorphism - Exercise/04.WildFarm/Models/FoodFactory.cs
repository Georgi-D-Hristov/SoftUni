using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class FoodFactory
    {
        public IFood CreateFood(string foodType, int quantity)
        {
            switch (foodType)
            {
                case "Vegetable":
                    return new Vegetable(quantity);

                case "Fruit":
                    return new Fruit(quantity);

                case "Meat":
                    return new Meat(quantity);

                case "Seeds":
                    return new Seeds(quantity);

                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}