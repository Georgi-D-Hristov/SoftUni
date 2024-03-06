namespace _01.Vehicles.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Truck : Vehicle
{
    private const double _AirConditionConsumption = 1.6;
    public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption+_AirConditionConsumption)
    {
    }

    public override void Refuel(double fuelAmount)
    {
        FuelQuantity-=fuelAmount*0.95;
    }

    public override string ToString()
    {
        return $"{nameof(Truck)}: {FuelQuantity:f2}";
    }
}

