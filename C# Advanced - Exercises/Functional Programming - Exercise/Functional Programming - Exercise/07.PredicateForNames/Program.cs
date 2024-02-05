var lenght = int.Parse(Console.ReadLine());

Predicate<string> isNameLengthLess = name => name.Length <= lenght;

Action<string[]> print = x => Console.WriteLine(string.Join("\n", x));

var names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(new Func<string, bool>(isNameLengthLess))
    .ToArray();

print(names);
