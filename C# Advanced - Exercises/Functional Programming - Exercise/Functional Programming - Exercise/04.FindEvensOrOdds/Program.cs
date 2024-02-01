var range = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var lower = range[0];
var upper = range[1];

Predicate<string> odd = command => command == "odd";

var command = Console.ReadLine();

if (odd(command))
{
    PrintOddNumbers(lower, upper);
}
else
{
    PrintEvenNumbers(lower, upper);
}

void PrintOddNumbers(int lower1, int upper1)
{
    for (int i = lower1; i <= upper1; i++)
    {
        if (i % 2 == 1)
        {
            Console.Write($"{i} ");
        }
    }
}

void PrintEvenNumbers(int i1, int upper2)
{
    for (int j = i1; j <= upper2; j++)
    {
        if (j % 2 == 0)
        {
            Console.Write($"{j} ");
        }
    }
}
