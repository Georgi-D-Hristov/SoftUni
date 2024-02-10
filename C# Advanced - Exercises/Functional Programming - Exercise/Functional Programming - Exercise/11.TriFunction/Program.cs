var number = int.Parse(Console.ReadLine());

var names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Func<string, int, bool> predicate = (name, num) =>
{
    var sumOfChars = 0;
    foreach (var ch in name)
    {
        sumOfChars += ch;
    }

    if (sumOfChars >= number)
    {
        return true;
    }

    return false;
};

var resultName = names.Where((name, number) => predicate(name, number)).First();

Console.WriteLine(resultName);
