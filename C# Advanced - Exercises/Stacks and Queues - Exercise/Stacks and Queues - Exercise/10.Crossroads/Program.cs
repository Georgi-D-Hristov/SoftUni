
var greenLightDuration = int.Parse(Console.ReadLine());
var freeWindowDuration = int.Parse(Console.ReadLine());



var cars = new Queue<string>();

var passedCars = 0;
var isCrashed = false;

var commandLine = Console.ReadLine();

while (commandLine != "END")
{
    if (commandLine == "green")
    {
        PassCrossroad(cars, greenLightDuration, freeWindowDuration);
    }
    else
    {
        cars.Enqueue(commandLine);
    }

    commandLine = Console.ReadLine();
}
if (!isCrashed)
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
}


void PassCrossroad(Queue<string> cars, int greenLightDuration, int freeWindowDuration)
{

    for (int i = 0; i < cars.Count; i++)
    {
        var car = cars.Peek();

        if (car.Length <= greenLightDuration)
        {
            cars.Dequeue();
            passedCars++;
            greenLightDuration -= car.Length;
        }
        else if (car.Length < greenLightDuration + freeWindowDuration)
        {
            cars.Dequeue();
            passedCars++;

        }
        else
        {
            var hitPart = car.Substring(car.Length - 1 - greenLightDuration + freeWindowDuration - 1, 1);
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{car} was hit at {hitPart}.");
            isCrashed=true;
        }
    }
}