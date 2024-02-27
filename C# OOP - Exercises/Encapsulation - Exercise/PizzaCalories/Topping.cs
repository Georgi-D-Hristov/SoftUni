namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const int _MaxToppingWeight = 50;
        private const int _MinToppingWeight = 1;

        private string _toppingType;
        private int _weight;

        private readonly Dictionary<string, double> toppings = new Dictionary<string, double> { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value < _MinToppingWeight || value > _MaxToppingWeight)
                {
                    throw new ArgumentException($"{_toppingType} weight should be in the range [1..50].");
                }
                _weight = value;
            }
        }

        public string ToppingType
        {
            get { return _toppingType.ToLower(); }
            set
            {
                if (!Enum.TryParse(value.ToLower(), out ToppingType toppingType))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                _toppingType = value;
            }
        }

        public double GetCalories()
        {
            return 2 * Weight * toppings[ToppingType];
        }
    }

    public enum ToppingType
    {
        meat,
        veggies,
        cheese,
        sauce
    }
}