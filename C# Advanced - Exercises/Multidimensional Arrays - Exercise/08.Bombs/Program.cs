var dimension = int.Parse(Console.ReadLine());

static void PrintResut(int[,] matrix, int aliveCells, int sum)
{
    Console.WriteLine($"Alive cells: {aliveCells}");
    Console.WriteLine($"Sum: {sum}");

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

var matrix = new int[dimension, dimension];

for (int row = 0; row < dimension; row++)
{
	var input = Console.ReadLine().Split().Select(int.Parse).ToList();
	for (int col = 0; col < dimension; col++)
	{
		matrix[row, col] = input[col];
	}
}
var bombsCoordinates = Console.ReadLine().Split().ToList();

var aliveCells = 0;
var sum = 0;
var bombs = new List<int>();

foreach (var coordinates in bombsCoordinates)
{
    var indexes = coordinates.Split(',').Select(int.Parse).ToList();
    var row = indexes[0];
    var col = indexes[1];
    var bomb = matrix[row, col];
    bombs.Add(bomb);
}

foreach (var coordinates in bombsCoordinates)
{
	var indexes = coordinates.Split(',').Select(int.Parse).ToList();
	var row = indexes[0];
	var col = indexes[1];
	var bomb = matrix[row, col];
    bombs.Remove(bomb);

	

	for (int i = Math.Max(0, row-1); i < Math.Min(dimension, row+2); i++)
	{
		for (int j = Math.Max(0, col-1); j < Math.Min(dimension, col+2); j++)
		{
			matrix[i, j] -= bomb;
		}
	}

    foreach (var item in bombs)
    {

    }


    //if (dimension==1)
    //   {
    //       PrintResut(matrix, aliveCells, sum);
    //	return;
    //   }

    //   if (row==0&&col==0)
    //{
    //       matrix[row, col + 1] -= bomb;
    //	matrix[row+1, col] -= bomb;
    //	matrix[row + 1, col + 1] += bomb;
    //   }
    //else if (row==0&&col>0&&col<matrix.GetLength(1)-1)
    //{
    //	matrix[row,col-1] -= bomb;
    //	matrix[row,col+1] -= bomb;
    //	matrix[row+1,col-1] -= bomb;
    //	matrix[row+1,col] -= bomb;
    //	matrix[row+1,col+1] -= bomb;
    //}
    //else if (row==0&&col==matrix.GetLength(1)-1)
    //{
    //	matrix[row, col - 1] -= bomb;
    //	matrix[row + 1, col] -= bomb;
    //	matrix[row+1,col-1] -= bomb;
    //}
    //else if (col==0&&row>0&&row<matrix.GetLength(0)-1)
    //{
    //	matrix[row - 1, col] -= bomb;
    //	matrix[row-1,col+1] -= bomb;
    //	matrix[row,col+1] -= bomb;
    //	matrix[row+1,col]-=bomb;
    //	matrix[row+1,col+1]-=bomb;
    //}
    //else if (col==0&&row==matrix.GetLength(0)-1)
    //{
    //	matrix[row - 1, col] -= bomb;
    //	matrix[row-1,col+1]-=bomb;
    //	matrix[row, col + 1] -= bomb;
    //}
    //else if (true)
    //{

    //}
}
foreach (var coordinates in bombsCoordinates)
{
    var indexes = coordinates.Split(',').Select(int.Parse).ToList();
    var row = indexes[0];
    var col = indexes[1];

    matrix[row, col] = 0;
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
	for (int j = 0; j < matrix.GetLength(1); j++)
	{
		if (matrix[i,j]>0)
		{
			sum += matrix[i, j];
			aliveCells++;
		}
	}
}

PrintResut(matrix, aliveCells, sum);
