var range = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

var lower = range[0];
var upper = range[1];

var numbers = new List<int>();

for (int i = lower; i <= upper; i++)
{
    numbers.Add(i);
}

Predicate<int> predicate = x => true;

var command = Console.ReadLine();

if (command == "even")
{
    predicate = x => x % 2 == 0;
}
else if (command == "odd")
{
    predicate = x => x % 2 != 0;
}

var filteredNumbers = numbers
    .Where(new Func<int, bool>(predicate));

Console.WriteLine(string.Join(" ", filteredNumbers));

