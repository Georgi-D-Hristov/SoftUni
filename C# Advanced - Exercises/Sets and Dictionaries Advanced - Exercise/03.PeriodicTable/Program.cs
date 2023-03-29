var periodicTable = new SortedSet<string>();

var numberOfLines = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfLines; i++)
{
    var line = Console.ReadLine().Split().ToList();

    foreach (var element in line)
    {
        periodicTable.Add(element);
    }
}

Console.WriteLine(string.Join(" ", periodicTable));