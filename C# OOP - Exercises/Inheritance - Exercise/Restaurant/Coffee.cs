namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine)
            : base(name, price: 3.5m, milliliters: 50)
        {

            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
