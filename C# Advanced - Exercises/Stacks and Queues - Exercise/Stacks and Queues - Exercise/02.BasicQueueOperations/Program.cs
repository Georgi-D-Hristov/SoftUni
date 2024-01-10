public class Program
{
    public static void Main(string[] args)
    {
        var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var elementsToDequeue = firstLine[1];
        var searchElement = firstLine[2];

        var queue = new Queue<int>(secondLine);

        for (int j = 0; j < elementsToDequeue; j++)
        {
            queue.Dequeue();
        }

        if (queue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (queue.Contains(searchElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}