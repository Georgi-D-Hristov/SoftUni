namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double caffeine)
            : base(name, price:3.50m, milliliters:50)
        {
            Caffeine= caffeine;
        }

        public double Caffeine { get; set; }
    }
}
