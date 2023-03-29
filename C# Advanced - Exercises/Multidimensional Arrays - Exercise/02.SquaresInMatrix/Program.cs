var matrixDemendions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

var rows = matrixDemendions[0];
var cols = matrixDemendions[1];

var matrix = new char[rows, cols];

if (rows<2&&cols<2)
{
    Console.WriteLine(0);
    return;
}

for (int i = 0; i < rows; i++)
{
    var input = Console.ReadLine().Split().Select(char.Parse).ToArray();

    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = input[j];
    }
}

var squares = 0;

for (int i = 0; i < rows - 1; i++)
{
    for (int j = 0; j < cols - 1; j++)
    {
        if (matrix[i, j] == matrix[i, j + 1]&& matrix[i, j] == matrix[i + 1, j]&& matrix[i, j] == matrix[i + 1, j + 1])
        {
            squares++;
        }
    }
}

Console.WriteLine(squares);