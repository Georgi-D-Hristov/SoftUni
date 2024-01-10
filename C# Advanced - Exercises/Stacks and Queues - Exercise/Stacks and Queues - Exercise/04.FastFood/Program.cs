var food = int.Parse(Console.ReadLine());

var orders = Console.ReadLine().Split().Select(int.Parse).ToList();

var queue = new Queue<int>(orders);

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

Console.WriteLine(!queue.Any() ? "Orders complete" : $"Orders left: {string.Join(" ", queue)}");