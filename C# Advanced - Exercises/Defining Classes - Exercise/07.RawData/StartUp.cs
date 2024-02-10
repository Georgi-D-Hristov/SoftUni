namespace _07.RawData;

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
            var carModel = carInfo[0];
            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);
            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];
            var tireOnePressure = double.Parse(carInfo[5]);
            var tireOneAge = int.Parse(carInfo[6]);
            var tireTwoPressure = double.Parse(carInfo[7]);
            var tireTwoAge = int.Parse(carInfo[8]);
            var tireThrePressure = double.Parse(carInfo[9]);
            var tireThreAge = int.Parse(carInfo[10]);
            var tireForePressure = double.Parse(carInfo[11]);
            var tireForeAge = int.Parse(carInfo[12]);

            var tire1 = new Tire(tireOneAge, tireOnePressure);
            var tire2 = new Tire(tireTwoAge, tireTwoPressure);
            var tire3 = new Tire(tireThreAge, tireThrePressure);
            var tire4 = new Tire(tireForeAge, tireForePressure);
            var tires = new List<Tire>();
            tires.Add(tire1);
            tires.Add(tire2);
            tires.Add(tire3);
            tires.Add(tire4);

            var cargo = new Cargo(cargoType, cargoWeight);
            var engine = new Engine(engineSpeed, enginePower);

            var car = new Car(carModel, engine, cargo, tires);

            cars.Add(car);
        }

        var printCommand = Console.ReadLine();

        if (printCommand == "fragile")
        {
            cars = cars.Where(c => c.Cargo.Type == "fragile").ToList();

            cars = cars.Where(c => c.Tires.Any(t => t.Pressure < 1)).ToList();
        }
        else
        {
            cars=cars.Where(c=>c.Cargo.Type== "flammable").ToList() ;
            cars = cars.Where(c=>c.Engine.Power>250).ToList() ;
        }

        Console.WriteLine(string.Join("\n", cars));
    }
}
