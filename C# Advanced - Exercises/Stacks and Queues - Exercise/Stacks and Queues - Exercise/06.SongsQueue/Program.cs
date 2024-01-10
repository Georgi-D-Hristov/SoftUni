var songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

var queue = new Queue<string>(songs);

while (queue.Count>0)
{
    var input = Console.ReadLine().Split().ToList();
    var command = input[0];

    switch (command)
    {
        case "Add":
            var song = string.Join(" ", input.Skip(1));
            if (queue.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
                break;
            }
            queue.Enqueue(song);
            break;
        case "Play":
            queue.Dequeue();
            break;
        case "Show":
            Console.WriteLine(string.Join(", ", queue));
            break;
        default:
            break;
    }
}
Console.WriteLine("No more songs!");
