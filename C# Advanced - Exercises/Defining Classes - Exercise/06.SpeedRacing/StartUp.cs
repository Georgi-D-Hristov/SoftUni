namespace _06.SpeedRacing;

public class StartUp
{
    public static void Main(string[] args)
    {
        var num = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < num; i++)
        {
            var carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries); 
            var model = carInfo[0];
            var fuelAmount = double.Parse(carInfo[1]);
            var fuelConsumption = double.Parse(carInfo[2]);

            var car = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(car);
        }

        string command;
        while ((command=Console.ReadLine())!="End")
        {
            var commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var model = commandInfo[1];
            var distance = double.Parse(commandInfo[2]);

            var car = cars.Where(c=>c.Model == model).FirstOrDefault();
            car.Drive(distance);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
