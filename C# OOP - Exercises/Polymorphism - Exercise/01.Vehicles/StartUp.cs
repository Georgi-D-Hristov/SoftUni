using _01.Vehicles.Models;

namespace _01.Vehicles;

public class StartUp
{
    public static void Main(string[] args)
    {
        var carInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var carFuelQuantity = double.Parse(carInput[1]);
        var carFuelConsumption = double.Parse(carInput[2]);
        var car = new Car(carFuelQuantity, carFuelConsumption);

        var truckInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var fuelQuantity = double.Parse(truckInput[1]);
        var fuelConsumption = double.Parse(truckInput[2]);
        var truck = new Truck(fuelQuantity, fuelConsumption);

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            var commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (commandArgs[0] == "Drive")
            {
                switch (commandArgs[1])
                {
                    case "Car":
                        car.Drive(double.Parse(commandArgs[2]), nameof(Car));
                        break;

                    case "Truck":
                        truck.Drive(double.Parse(commandArgs[2]), nameof(Truck));
                        break;
                }
            }
            if (commandArgs[0] == "Refuel")
            {
                switch (commandArgs[1])
                {
                    case "Car":
                        car.Refuel(double.Parse(commandArgs[2]));
                        break;

                    case "Truck":
                        truck.Refuel(double.Parse(commandArgs[2]));
                        break;
                }
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }
}