var size = int.Parse(Console.ReadLine());
var matrix = new char[size, size];

var commandsInfo = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
var squirrelRow = -1;
var squirrelCol = -1;
var nuts = 0;
var isOutOfBorders = false;
var isTrapped = false;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    var input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = input[j];
        if (matrix[i, j] == 's')
        {
            squirrelRow = i;
            squirrelCol = j;
        }
    }
}

foreach (var command in commandsInfo)
{
    switch (command)
    {
        case "up":
            squirrelRow--;
            CheckMove();
            break;
        case "down":
            squirrelRow++;
            CheckMove();
            break;
        case "left":
            squirrelCol--;
            CheckMove();
            break;
        case "right":
            squirrelCol++;
            CheckMove();
            break;
        default:
            break;
    }
    if (isOutOfBorders || isTrapped)
    {
        break;
    }
    if (nuts == 3)
    {
        break;
    }
}
if (nuts != 3 && !isTrapped && !isOutOfBorders)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}
Console.WriteLine($"Hazelnuts collected: {nuts}");

void CheckMove()
{
    if (squirrelRow < 0 || squirrelCol < 0 || squirrelRow >= matrix.GetLength(0) || squirrelCol >= matrix.GetLength(1))
    {
        Console.WriteLine("The squirrel is out of the field.");
        isOutOfBorders = true;
    }
    else if (matrix[squirrelRow, squirrelCol] == 't')
    {
        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
        isTrapped = true;
    }
    else if (matrix[squirrelRow, squirrelCol] == 'h')
    {
        nuts++;
        matrix[squirrelRow, squirrelCol] = '*';
        if (nuts == 3)
        {
            Console.WriteLine("Good job! You have collected all hazelnuts!");
        }
    }
}