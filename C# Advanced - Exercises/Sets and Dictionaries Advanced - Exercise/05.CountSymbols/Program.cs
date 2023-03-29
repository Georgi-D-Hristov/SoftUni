var result = new SortedDictionary<char, int>();

var inputText = Console.ReadLine().ToCharArray();

foreach (char caracter in inputText)
{
    if (!result.ContainsKey(caracter))
    {
        result[caracter] = 1;
    }
    else
    {
        result[caracter]++;
    }
}

foreach (var item in result)
{
    Console.WriteLine($"{item.Key}: {item.Value} time/s");
}
