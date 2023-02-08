var food = int.Parse(Console.ReadLine());
var queue = new Queue<int>();

var orders = Console.ReadLine().Split().Select(int.Parse).ToList();

for (int i = 0; i < orders.Count; i++)
{
    queue.Enqueue(orders[i]);
}

Console.WriteLine(queue.Max());

while (queue.Any() && food > 0)
{
    var order = queue.Peek();
    if (food - order >= 0)
    {
        queue.Dequeue();
        food -= order;
    }
    else
    {
        food -= order;
    }
}

if (!queue.Any())
{
    Console.WriteLine("Orders complete");
}
else
{
    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
}