var input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

Action<string> print = word => Console.WriteLine($"Sir {word}");

foreach (var word in input)
{
    print(word);
}