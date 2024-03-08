namespace _01.Vehicles.Models;

using _01.Vehicles.Contracts;
using System;

public abstract class Vehicle : IVehicle
{
    private double _fuelQuantity;
    private readonly double _tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            FuelQuantity = tankCapacity;
        }
        else
        {
            FuelQuantity = fuelQuantity;
        }

        FuelConsumption = fuelConsumption;
        TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get => _fuelQuantity;
        set
        {
            _fuelQuantity = value;
        }
    }

    public virtual double FuelConsumption { get; set; }

    public double TankCapacity
    {
        get => _tankCapacity;
        init => _tankCapacity = value;
    }

    public virtual void Drive(double distance, string className)
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
        if (fuelAmount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        var totalAmountFuel = FuelQuantity + fuelAmount;
        if (totalAmountFuel <= TankCapacity)
        {
            FuelQuantity += fuelAmount;
        }
        else
        {
            Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
        }
    }
}