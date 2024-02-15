using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity  { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > GetCount)
            {
                Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name)
        {
            var drink = Drinks.FirstOrDefault(x => x.Name == name);
            if (drink != null)
            {
                Drinks.Remove(drink);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Drink GetLongest()
        {
            var drink = Drinks.OrderByDescending(d=>d.Volume).FirstOrDefault();
            return drink;
        }
        public Drink GetCheapest()
        {
            var drink = Drinks.OrderBy(d=>d.Price).FirstOrDefault();
            return drink;
        }
        public string BuyDrink(string name)
        {
            var drink = Drinks.First(d=>d.Name == name);
            return drink.ToString();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drinks available:");
            foreach (var drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
