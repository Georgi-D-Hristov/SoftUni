using System.Data;

var boaedSize = int.Parse(Console.ReadLine());

var board = new char[boaedSize][];

for (int i = 0; i < board.GetLength(0); i++)
{
    var inputData = Console.ReadLine().ToCharArray();
    board[i] = inputData;
}

if (boaedSize < 3)
{
    Console.WriteLine(0);
    return;
}

var mostAttacingKnight = 0;
var rowMostAttaking = -1;
var colMostAttaking = -1;
var removedKnights = 0;
var attackingKnights = 0;
bool isAttakPossible = true;

//1. Define attacking positions of all knights

//row-2 col-1*
//row-1 col-2*
//row-2 col+1*
//row-1 col+2*
//row+2 col-1*
//row+1 col-2*
//row+2 col+1*
//row+1 col+2*

while (isAttakPossible)
{
    for (int row = 0; row < board.GetLength((0)); row++)
    {
        for (int col = 0; col < board.GetLength(0); col++)
        {
            if (board[row][col] == 'K')
            {
                if (IsValidCoordinate(row - 2, col - 1, boaedSize) && board[row - 2][col - 1] == 'K')//1
                {
                    attackingKnights++;

                }
                else if (IsValidCoordinate(row - 1, col - 2, boaedSize) && board[row - 1][col - 2] == 'K')//2
                {
                    attackingKnights++;
                }
                else if (IsValidCoordinate(row - 2, col + 1, boaedSize) && board[row - 2][col + 1] == 'K')//3
                {
                    attackingKnights++;
                }
                else if (IsValidCoordinate(row - 1, col + 2, boaedSize) && board[row - 1][col + 2] == 'K')//4
                {
                    attackingKnights++;
                }
                else if (IsValidCoordinate(row + 2, col - 1, boaedSize) && board[row + 2][col - 1] == 'K')//5
                {
                    attackingKnights++;
                }
                else if (IsValidCoordinate(row + 1, col - 2, boaedSize) && board[row + 1][col - 2] == 'K')//6
                {
                    attackingKnights++;
                }
                else if (IsValidCoordinate(row + 2, col + 1, boaedSize) && board[row + 2][col + 1] == 'K')//7
                {
                    attackingKnights++;
                }
                else if (IsValidCoordinate(row + 1, col + 2, boaedSize) && board[row + 1][col + 2] == 'K')//8
                {
                    attackingKnights++;
                }
                else
                {
                    isAttakPossible = false;
                }

                if (attackingKnights >= mostAttacingKnight)
                {
                    mostAttacingKnight = attackingKnights;
                    attackingKnights = 0;
                    rowMostAttaking = row;
                    colMostAttaking = col;
                    removedKnights++;
                }
            }
        }
    }

    if (mostAttacingKnight > 0)
    {
        board[rowMostAttaking][colMostAttaking] = 'O';
        mostAttacingKnight = 0;
    }
}

Console.WriteLine(removedKnights);

//2. Find most attacking knight

//3. Remove the most attacking knight

//4. Return to point 1 until attackingKnights==0

static bool IsValidCoordinate(int row, int col, int boardSize)
{
    return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
}

