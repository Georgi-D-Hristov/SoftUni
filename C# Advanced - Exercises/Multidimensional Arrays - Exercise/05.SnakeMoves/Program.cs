var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

var rows = dimensions[0];
var columns = dimensions[1];

var matrix = new char[rows, columns];

var snake = Console.ReadLine().ToCharArray();
var snakeCounter = 0;

var pattern = new List<char>();

for (int i = 0; i < rows; i++)
{
    if (i % 2 == 0)
    {
        for (int j = 0; j < columns; j++)
        {


            if (snakeCounter == snake.Length)
            {
                snakeCounter = 0;
            }

            matrix[i, j] = snake[snakeCounter++];
        }
    }
    else
    {
        for (int j = columns - 1; j >= 0; j--)
        {
            if (snakeCounter == snake.Length)
            {
                snakeCounter = 0;
            }

            matrix[i, j] = snake[snakeCounter++];
        }
    }

}
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j]);
    }
    Console.WriteLine();
}