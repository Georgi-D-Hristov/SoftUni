namespace _01.Vehicles.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IVehicle
{
    double FuelQuantity {  get; set; }
    double FuelConsumption { get; init; }

    void Drive(int distance, string className);
    void Refuel(double fuelAmount);
}
