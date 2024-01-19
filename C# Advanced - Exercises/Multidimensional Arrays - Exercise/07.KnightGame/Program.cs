var boaedSize = int.Parse(Console.ReadLine());

var board = new char[boaedSize][];

for (int i = 0; i < board.GetLength(0); i++)
{
    var inputData = Console.ReadLine().ToCharArray();
    board[i] = inputData;
}

var removedKnights = 0;
var attackingKnights =0;

//1. Define attacking positions of all knights

//2. Find most attacking knight

//3. Remove the most attacking knight

//4. Return to point 1 until attackingKnights==0

