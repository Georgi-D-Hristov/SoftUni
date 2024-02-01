Func<int[], int> minFunc = min => min.Min();

var input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(minFunc(input));
