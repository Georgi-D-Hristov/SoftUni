public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var elementsToPop = input[1];
        var searchElement = input[2];
        var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var stack = new Stack<int>(elements);

        for (int j = 0; j < elementsToPop; j++)
        {
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (stack.Contains(searchElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}