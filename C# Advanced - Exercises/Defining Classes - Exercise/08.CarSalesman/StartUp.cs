namespace _08.CarSalesman;

public class StartUp
{
    public static void Main(string[] args)
    {
        var num = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        var engines = new List<Engine>();

        for (int i = 0; i < num; i++)
        {
            var enginInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var model = enginInfo[0];
            var power = int.Parse(enginInfo[1]);
            if (enginInfo.Length == 4)
            {
                var displacement = int.Parse(enginInfo[2]);
                var efficiency = enginInfo[3];
                var engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }
            else if (enginInfo.Length == 3)
            {
                var parammeter = int.TryParse(enginInfo[2], out var param);
                if (parammeter)
                {
                    var displacement = param;
                    var engine = new Engine(model, power, displacement);
                    engines.Add(engine);
                }
                else
                {
                    var efficiency = enginInfo[2];
                    var engine = new Engine(model, power, efficiency);
                    engines.Add(engine);
                }
            }
            else
            {
                var engine = new Engine(model, power);
                engines.Add(engine);
            }
        }

        var secondNum = int.Parse(Console.ReadLine());

        for (int i = 0; i < secondNum; i++)
        {
            var carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var carModel = carInfo[0];
            var carEngineModel = carInfo[1];

            if (carInfo.Length == 3)
            {
                var parameter = int.TryParse(carInfo[2], out var param);
                if (parameter)
                {
                    var weight = param;
                    var engine = engines.Where(e => e.Model == carEngineModel).FirstOrDefault();

                    var car = new Car(carModel, engine, weight);
                    cars.Add(car);
                }
                else
                {
                    var color = carInfo[2];
                    var engine = engines.Where(e => e.Model == carEngineModel).FirstOrDefault();
                    var car = new Car(carModel, engine, color);
                    cars.Add(car);
                }
            }
            else if(carInfo.Length == 4) 
            {
                var engine = engines.Where(e => e.Model == carEngineModel).FirstOrDefault();
                var weight = int.Parse(carInfo[2]);
                var color = carInfo[3];

                var car = new Car(carModel, engine, weight, color);
                cars.Add(car);
            }
            else
            {
                var engine = engines.Where(e => e.Model == carEngineModel).FirstOrDefault();
                var car = new Car(carModel, engine);
                cars.Add(car);
            }
        }

        foreach ( var car in cars )
        {
            Console.WriteLine(car);
        }
    }
}
