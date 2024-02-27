namespace PizzaCalories
{
    using PizzaCalories.DoughModels;
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private const int _MaxNameLength = 15;
        private const int _MinNameLength = 1;
        private const int _MaxToppings = 10;

        private string _name;
        private List<Topping> _toppings;

        public Pizza(string name, Dough dough)
        {
            _name = name;
            Dough = dough;
            _toppings = new List<Topping>();
        }

        public IReadOnlyCollection<Topping> MyProperty
        {
            get { return _toppings; }
        }

        public Dough Dough { get; private set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > _MaxNameLength || value.Length < _MinNameLength)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                _name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (_toppings.Count > _MaxToppings)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
            _toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double toppingCalories = 0;
            double doughCalories = Dough.GetCalories();
            foreach (var topping in _toppings)
            {
                toppingCalories += topping.GetCalories();
            }
            double totalCalories = doughCalories + toppingCalories;
            return totalCalories;
        }
    }
}