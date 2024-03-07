namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double _AirConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + _AirConditionConsumption, tankCapacity)
        {
        }

        public void DriveEmpty(double distance)
        {
            FuelConsumption -= _AirConditionConsumption;
            Drive(distance, nameof(Bus));
        }
    }
}