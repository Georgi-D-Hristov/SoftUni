var inputLines = int.Parse(Console.ReadLine());
var tour = new Queue<int[]>();
var indexPump = 0;

for (int i = 0; i < inputLines; i++)
{
    var pumpStop = Console.ReadLine().Split().Select(int.Parse).ToArray();

    tour.Enqueue(pumpStop);
}

while (true)
{
    var fuel = 0;

    foreach (var pump in tour)
    {
        fuel += pump[0] - pump[1];
        if (fuel < 0)
        {
            indexPump++;
            tour.Enqueue(tour.Dequeue());
            break;
        }
    }

    if (fuel >= 0)
    {
        break;
    }
}
Console.WriteLine(indexPump);