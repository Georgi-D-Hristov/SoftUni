namespace _01.Vehicles.Contracts;

public interface IVehicle
{
    double FuelQuantity { get; set; }
    double FuelConsumption { get; set; }

    double TankCapacity { get; init; }

    void Drive(double distance, string className);

    void Refuel(double fuelAmount);
}