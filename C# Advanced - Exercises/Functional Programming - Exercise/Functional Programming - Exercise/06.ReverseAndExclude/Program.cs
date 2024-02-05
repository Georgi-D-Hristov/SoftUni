var input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

var divisor = int.Parse(Console.ReadLine());

Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers.Reverse()));

Func<int[], int[]> reverce = x => x;
Func<int, bool> isDivisable = x => x % divisor != 0;

input = input.Where(new Func<int, bool>(isDivisable)).ToArray();

print(input);