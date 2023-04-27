namespace NeedForSpeed
{

    public abstract class Vehicle
    {
        public const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        protected Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public double Fuel { get; set; }


        public int HorsePower { get; set; }

        public virtual double DefaultFuelConsumption { get; set; } = DEFAULT_FUEL_CONSUMPTION;

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double kilometers)
        {
            FuelConsumption = kilometers * DefaultFuelConsumption;
            Fuel -= FuelConsumption;
        }
    }
}
