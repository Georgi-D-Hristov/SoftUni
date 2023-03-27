var uniqueNames = new HashSet<string>();
var numberOfNames = int.Parse(Console.ReadLine());

for(int i = 0; i < numberOfNames; i++)
{
    var name = Console.ReadLine();
    uniqueNames.Add(name);
}

Console.WriteLine(string.Join("\n",uniqueNames));
