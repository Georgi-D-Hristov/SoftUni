namespace _01.Vehicles.Models;

using _01.Vehicles.Contracts;
using System;

public abstract class Vehicle : IVehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; set; }
    public virtual double FuelConsumption { get; init; }

    public void Drive(double distance, string className)
    {
        var needFuelAmount = distance * FuelConsumption;
        if (needFuelAmount > FuelQuantity)
        {
            Console.WriteLine($"{className} needs refueling");
        }
        else
        {
            FuelQuantity -= needFuelAmount;
            Console.WriteLine($"{className} travelled {distance} km");
        }
    }

    public virtual void Refuel(double fuelAmount)
    {
        FuelQuantity += fuelAmount;
    }
}