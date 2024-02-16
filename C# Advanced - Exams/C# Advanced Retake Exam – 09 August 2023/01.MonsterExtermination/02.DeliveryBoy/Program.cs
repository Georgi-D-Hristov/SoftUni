using System.Reflection.Metadata.Ecma335;

var sizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

var matrix = new char[sizes[0], sizes[1]];
var boyRow = -1;
var boyCol = -1;
var addressRow = -1;
var addressCol = -1;
var restaurantRow = -1;
var restaurantCol = -1;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    var input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i,j] = input[j];
        if (matrix[i, j] == 'B')
        {
            boyRow = i;
            boyCol=j;
        }
        if (matrix[i,j]=='A')
        {
            addressRow = i;
            addressCol = j;
        }
        if (matrix[i, j] == 'P')
        {
            restaurantRow=i;
            restaurantCol=j;
        }
    }
}

while (!OutOfBoundares())
{
    var command = Console.ReadLine();

    //switch (command)
    //{
    //    case "down" when matrix[boyRow+1, boyCol]!='*':break;
    //    case "up" when matrix[boyRow - 1, boyCol] != '*': break;
    //    case "left" when matrix[boyRow, boyCol - 1] != '*': break;
    //    case "right" when matrix[boyRow, boyCol + 1] != '*': break;
    //    default:
    //        break;
    //}
    Move(command);
}

void Move(string command) 
{

    switch (command)
    {
        case "down" :
            boyRow++;
            CheckMove();
            break;
        case "up" :
            boyCol--;
            CheckMove();
            break;
        case "left":
            boyCol--;
            CheckMove();
            break;
        case "right":
            boyCol++;
            CheckMove();
            break;
        default:
            break;
    }
}

void CheckMove()
{
    if (OutOfBoundares())
    {
        Console.WriteLine("The delivery is late. Order is canceled.");
    }
    if (matrix[boyRow,boyCol]=='*')
    {
       
    }
}

bool OutOfBoundares()
{
    if (boyRow < 0 || boyRow >= matrix.GetLength(0) || boyCol < 0 || boyCol >= matrix.GetLength(1))
    {
        return true;
    }
    return false;
}