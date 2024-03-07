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
        var tankCapacity = double.Parse(carInput[3]);
        var car = new Car(carFuelQuantity, carFuelConsumption, tankCapacity);

        var truckInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var fuelQuantity = double.Parse(truckInput[1]);
        var fuelConsumption = double.Parse(truckInput[2]);
        var truckTankCapacity = double.Parse(truckInput[3]);
        var truck = new Truck(fuelQuantity, fuelConsumption, truckTankCapacity);

        var busInput = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var busFuelQuantity = double.Parse(busInput[1]);
        var busFuelConsumption = double.Parse(busInput[2]);
        var busTankCapacity = double.Parse(busInput[3]);
        var bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

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

                    case "Bus":
                        bus.Drive(double.Parse(commandArgs[2]), nameof(Bus));
                        break;
                }
            }

            try
            {
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

                        case "Bus":
                            bus.Refuel(double.Parse(commandArgs[2]));
                            break;
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            if (commandArgs[0] == "DriveEmpty")
            {
                bus.DriveEmpty(double.Parse(commandArgs[2]));
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }
}