var numberRows = int.Parse(Console.ReadLine());

var matrix = new int[numberRows][];

for (int i = 0; i < numberRows; i++)
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    matrix[i] = new int[input.Length];
    for (int j = 0; j < input.Length; j++)
    {
        matrix[i][j] = input[j];
    }
}

//Analyze

for (int i = 0; i < matrix.Length - 1; i++)
{
    if (matrix[i].Length == matrix[i + 1].Length)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            matrix[i][j] *= 2;
            matrix[i + 1][j] *= 2;
        }
    }
    else
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            matrix[i][j] /= 2;
        }
        for (int j = 0; j < matrix[i + 1].Length; j++)
        {
            matrix[i + 1][j] /= 2;
        }
    }
}

//Commands

var commandInput = Console.ReadLine();
while (commandInput != "End")
{
    var commandArgs = commandInput.Split().ToArray();
    var command = commandArgs[0];

    switch (command)
    {
        case "Add":
            var row = int.Parse(commandArgs[1]);
            var col = int.Parse(commandArgs[2]);
            var value = int.Parse(commandArgs[3]);

            if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
            {
                matrix[row][col] += value;
            }
            break;

        case "Subtract":
            row = int.Parse(commandArgs[1]);
            col = int.Parse(commandArgs[2]);
            value = int.Parse(commandArgs[3]);

            if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
            {
                matrix[row][col] -= value;
            }
            break;

        default:
            break;
    }

    commandInput = Console.ReadLine();
}

PrintMatrix(matrix);

static void PrintMatrix(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            Console.Write(matrix[i][j] + " ");
        }
        Console.WriteLine();
    }
}