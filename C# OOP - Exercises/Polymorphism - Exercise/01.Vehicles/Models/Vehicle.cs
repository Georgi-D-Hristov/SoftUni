using System.Threading.Channels;

namespace _01.Vehicles.Models;

using _01.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Vehicle : IVehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }
    public double FuelQuantity { get; set; }
    public virtual double FuelConsumption { get; init; }
    public void Drive(int distance, string className)
    {
        var needFuelAmount = distance * FuelConsumption;
        if (needFuelAmount>FuelQuantity)
        {
            Console.WriteLine($"{className} need refueling");
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
