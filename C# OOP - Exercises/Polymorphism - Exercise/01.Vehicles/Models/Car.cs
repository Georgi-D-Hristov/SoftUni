namespace _01.Vehicles.Models;

public class Car : Vehicle
{
    private const double _AirConditionConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + _AirConditionConsumption)
    {
    }

    public override string ToString()
    {
        return $"{nameof(Car)}: {FuelQuantity:f2}";
    }
}