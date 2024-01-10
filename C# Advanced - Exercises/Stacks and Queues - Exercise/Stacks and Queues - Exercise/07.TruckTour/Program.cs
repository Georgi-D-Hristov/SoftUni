var inputLines = int.Parse(Console.ReadLine());
var tour = new Queue<string>();
var indexPump = 0;
var tank = 0;

for (int i = 0; i < inputLines; i++)
{
    var pumpStop = Console.ReadLine();

    tour.Enqueue(pumpStop);
}

while (tour.Count > 0)
{
    var currentStop = tour.Peek();

    var pumpArgs = currentStop.Split().Select(int.Parse).ToArray();
    var petrol = pumpArgs[0];
    var distance = pumpArgs[1];

    tank += petrol;

    if (tank < distance)
    {
        indexPump++;
        tank = 0;
        tour.Dequeue();
        tour.Enqueue(currentStop);
    }
    else
    {
        tank -= distance;
        tour.Dequeue();
    }
}

Console.WriteLine(indexPump);