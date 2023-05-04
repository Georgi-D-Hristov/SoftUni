namespace ShoppingSpree
{
    using System;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }


        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name cannot be an empty string");
                }

                name = value;
            }
        }

        public void AddProduct(Product product) 
        {
            bag.Add(product);
        }
        public void reduseMoney(Product product) 
        {
            Money -= product.Cost;
        }
        public bool IsBagEmpty()
        {
            if (!bag.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string ShowBagProducts()
        {
            return string.Join(", ", bag.Select(x => x.Name));
        }
    }
}
