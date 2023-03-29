var countOfNumbers = int.Parse(Console.ReadLine());
var dictionary = new Dictionary<int, int>();

for (int i = 0; i < countOfNumbers; i++)
{
    var number = int.Parse(Console.ReadLine());

    if (dictionary.ContainsKey(number))
    {
        dictionary[number]++;
    }
    else 
    {
        dictionary[number] = 1;
    }
}

foreach (var num in dictionary)
{
    if (num.Value%2==0)
    {
        Console.WriteLine(num.Key);
    }
}