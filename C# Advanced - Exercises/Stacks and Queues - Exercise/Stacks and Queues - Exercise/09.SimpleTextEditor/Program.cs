var text = string.Empty;
var numberOfCommands = int.Parse(Console.ReadLine());
var state = new Stack<string>();

for (int i = 0; i < numberOfCommands; i++)
{
    var commandLine = Console.ReadLine()
        .Split()
        .ToList();

    var command = int.Parse(commandLine[0]);

    if (command == 1)
    {
        state.Push(text);
        text += commandLine[1];
    }
    else if (command == 2)
    {
        var numberOfChars = int.Parse(commandLine[1]);
        state.Push(text);

        text = text.Substring(0, text.Length - numberOfChars);
    }
    else if (command == 3)
    {
        var indexOfChar = int.Parse(commandLine[1]);

        Console.WriteLine(text.Substring(indexOfChar - 1, 1));
    }
    else if (command == 4)
    {
        text = state.Pop();
    }
}