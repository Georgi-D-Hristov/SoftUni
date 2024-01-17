var dimesions = Console.ReadLine().Split().Select(int.Parse).ToList();

static void PrintMatrix(string[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

static void SwapElements(string[,] matrix, int firstCoordinateRow, int firstCoordinateColumn, int secondCoordinateRow, int secondCoordinateColumn)
{
    var tempValue = matrix[firstCoordinateRow, firstCoordinateColumn];
    matrix[firstCoordinateRow, firstCoordinateColumn] = matrix[secondCoordinateRow, secondCoordinateColumn];
    matrix[secondCoordinateRow, secondCoordinateColumn] = tempValue;
}

var rows = dimesions[0];
var cols = dimesions[1];

var matrix = new string[rows, cols];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    var matrixInput = Console.ReadLine().Split().ToList();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = matrixInput[j];
    }
}
var command = Console.ReadLine();

while (command != "END")
{
    var commandArgs = command.Split().ToList();

    if (commandArgs[0] != "swap"||commandArgs.Count>5)
    {
        Console.WriteLine("Invalid input!");
    }
    else
    {
        var firstCoordinateRow = int.Parse(commandArgs[1]);
        var firstCoordinateColumn = int.Parse(commandArgs[2]);
        var secondCoordinateRow = int.Parse(commandArgs[3]);
        var secondCoordinateColumn = int.Parse(commandArgs[4]);

        if (firstCoordinateRow > matrix.GetLength(0) || firstCoordinateRow < 0 ||
            firstCoordinateColumn > matrix.GetLength(1) || firstCoordinateColumn < 0 ||
            secondCoordinateRow > matrix.GetLength(0) || secondCoordinateColumn > matrix.GetLength(1) ||
            secondCoordinateColumn > matrix.GetLength(1) || secondCoordinateColumn < 0)
        {
            Console.WriteLine("Invalid input!");
        }
        else
        {
            SwapElements(matrix, firstCoordinateRow, firstCoordinateColumn, secondCoordinateRow, secondCoordinateColumn);
            PrintMatrix(matrix);
        }
    }

    command = Console.ReadLine();
}