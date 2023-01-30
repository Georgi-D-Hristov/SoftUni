﻿public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var numberOfElements = input[0];
        var elementsToPop = input[1];
        var searchElement = input[2];
        var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var stack = new Stack<int>();

        //Insert elements into the stack
        for (int i = 0; i < numberOfElements; i++)
        {
            stack.Push(elements[i]);
        }

        //Pop elements from stack
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