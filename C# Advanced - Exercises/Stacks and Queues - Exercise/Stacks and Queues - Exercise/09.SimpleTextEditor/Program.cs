var text = new Stack<string>();
var numberOfCommands = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfCommands; i++)
{
    var commandLine = Console.ReadLine()
        .Split()
        .ToList();

    var command = int.Parse(commandLine[0]);

    if (command == 1)
    {
        text.Push(commandLine[1]);
    }
    else if (command == 2)
    {
        var numberOfChars = int.Parse(commandLine[1]);
        var currentText = text.Peek();
        if (numberOfChars>currentText.Length)
        {
            text.Push(string.Empty);
        }
        else
        {
            currentText=currentText.Substring(0, text.Peek().Length - numberOfChars);
        }
        text.Push(currentText);
    }
    else if (command == 3)
    {
        var indexOfChar = int.Parse(commandLine[1]);
     
        var currentText = text.Peek();
        if (indexOfChar > currentText.Length)
        {
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine(currentText.Substring(indexOfChar - 1, 1));
        }

        
    }
    else if (command == 4)
    {
        text.Pop();
    }
}