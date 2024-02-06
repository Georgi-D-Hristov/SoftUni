var endOfRange = int.Parse(Console.ReadLine());
var devisors = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

var numbers = new List<int>();

for (int i = 1; i <= endOfRange; i++)
{
    numbers.Add(i);
}

//Predicate<int> isDivider = x=>x%
Func<int[], int, bool> predicate = (arr, i) =>
{
    bool isDivisable = true;
    foreach (var devisor in devisors)
    {
        if (i % devisor != 0)
        {
            return false;
        }
    }

    return isDivisable;
};

var results = numbers
    .Where(number => predicate(devisors, number));

Console.WriteLine(string.Join(" ", results));

