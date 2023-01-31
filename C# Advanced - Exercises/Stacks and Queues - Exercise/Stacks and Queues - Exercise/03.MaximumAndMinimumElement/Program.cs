internal class Program
{
    private static void Main(string[] args)
    {
        var numOfQueries = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();

        for (int i = 0; i < numOfQueries; i++)
        {
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            switch (command[0])
            {
                case 1:
                    stack.Push(command[1]);
                    break;
                case 2:
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    stack.Pop();
                    break;
                case 3:
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine(stack.Max());
                    break;
                case 4:
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine(stack.Min());
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", stack));
    }
}