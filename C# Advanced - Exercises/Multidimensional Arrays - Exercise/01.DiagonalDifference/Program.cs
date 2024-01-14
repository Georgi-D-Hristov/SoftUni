var matrixSize = int.Parse(Console.ReadLine());

var matrix = new int[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    var inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

	for (int col = 0; col < matrixSize; col++)
	{
		matrix[row,col] = inputLine[col];
	}
}

var primaryDiagonal = 0;
var secondaryDiagonal = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
	primaryDiagonal += matrix[i,i];
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    secondaryDiagonal+= matrix[row,matrix.GetLength(0)-1-row];
}

var absoluteDifference = Math.Abs(primaryDiagonal - secondaryDiagonal);

Console.WriteLine(absoluteDifference);
