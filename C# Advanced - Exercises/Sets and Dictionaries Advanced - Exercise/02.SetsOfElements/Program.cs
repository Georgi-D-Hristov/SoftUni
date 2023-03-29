var lengthOfTwoSets = Console.ReadLine().Split().Select(int.Parse).ToArray();

var firstSetLength = lengthOfTwoSets[0];
var secondSetLength = lengthOfTwoSets[1];

var firstSet = new List<int>();
var secondSet = new List<int>();

var resultSet = new HashSet<int>();

for (int i = 0; i < firstSetLength; i++)
{
    var number = int.Parse(Console.ReadLine());
    firstSet.Add(number);
}

for (int i = 0; i < secondSetLength; i++)
{
    var number = int.Parse(Console.ReadLine());
    secondSet.Add(number);
}

foreach(var number in firstSet)
{
    if (secondSet.Contains(number))
    {
        resultSet.Add(number);
    }
}

Console.WriteLine(string.Join(" ", resultSet));
