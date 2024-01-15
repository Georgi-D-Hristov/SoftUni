var sizeArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var rows = sizeArgs[0];
var cols = sizeArgs[1];
var matrix = new char[rows, cols];
var squares = 0;

//Fill matrix
for (int i = 0; i < rows; i++)
{
    var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = input[j];
    }
}

//Check for squares
for (int i = 0; i < (matrix.GetLength(0) - 1); i++)
{
    for (int j = 0; j < (matrix.GetLength(1) - 1); j++)
    {
        bool checkForSquare = matrix[i, j] == matrix[i, j + 1] &&
                              matrix[i, j] == matrix[i + 1, j] &&
                              matrix[i + 1, j] == matrix[i + 1, j + 1];
        if (checkForSquare)
        {
            squares++;
        }
    }
}

Console.WriteLine(squares);