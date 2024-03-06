namespace _01.Vehicles.Models;

using _01.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

