var input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

Action<string> print = word => Console.WriteLine(word);

foreach (var word in input)
{
    print(word);
}
