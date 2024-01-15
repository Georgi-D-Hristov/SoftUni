var matrixDemendions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

var rows = matrixDemendions[0];
var cols = matrixDemendions[1];

var matrix = new int[rows, cols];


for (int i = 0; i < rows; i++)
{
    var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = input[j];
    }
}

var bigestSum = int.MinValue;
var resultMatrix = new int[3, 3];

for (int i = 0; i < matrix.GetLongLength(0) - 2; i++)
{
    for (int j = 0; j < matrix.GetLength(1) - 2; j++)
    {
        var sum = matrix[i, j] +
                  matrix[i, j + 1] +
                  matrix[i, j + 2] +
                  matrix[i + 1, j] +
                  matrix[i + 1, j + 1] +
                  matrix[i + 1, j + 2] +
                  matrix[i + 2, j] +
                  matrix[i + 2, j + 1] +
                  matrix[i + 2, j + 2];

        if (sum > bigestSum)
        {
            bigestSum = sum;

            resultMatrix[0, 0] = matrix[i, j];
            resultMatrix[0, 1] = matrix[i, j + 1];
            resultMatrix[0, 2] = matrix[i, j + 2];
            resultMatrix[1, 0] = matrix[i + 1, j];
            resultMatrix[1, 1] = matrix[i + 1, j + 1];
            resultMatrix[1, 2] = matrix[i + 1, j + 2];
            resultMatrix[2, 0] = matrix[i + 2, j];
            resultMatrix[2, 1] = matrix[i + 2, j + 1];
            resultMatrix[2, 2] = matrix[i + 2, j + 2];
        }
    }
}

Console.WriteLine($"Sum = {bigestSum}");

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(resultMatrix[i, j] + " ");
    }
    Console.WriteLine();
}




