namespace _01.Vehicles.Models;

public class Truck : Vehicle
{
    private const double _AirConditionConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + _AirConditionConsumption, tankCapacity)
    {
    }

    public override void Refuel(double fuelAmount)
    {
        if (fuelAmount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        var totalAmountFuel = FuelQuantity + fuelAmount;
        if (totalAmountFuel <= TankCapacity)
        {
            FuelQuantity += fuelAmount * 0.95;
        }
        else
        {
            Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
        }
    }

    public override string ToString()
    {
        return $"{nameof(Truck)}: {FuelQuantity:f2}";
    }
}