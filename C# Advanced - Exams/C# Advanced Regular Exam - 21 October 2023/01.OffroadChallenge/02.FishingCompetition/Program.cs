


var size = int.Parse(Console.ReadLine());

var matrix = new char[size, size];
var shipRows = -1;
var shipCols = -1;
var reachWirpool = false;

for (int i = 0; i < size; i++)
{
    var input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < size; j++)
    {
        matrix[i, j] = input[j];
        if (matrix[i, j] == 'S')
        {
            shipRows = i;
            shipCols = j;
        }
    }
}

string command;
while ((command = Console.ReadLine()) != "collect the nets")
{
 
    switch (command)
    {
        case "up":
            shipRows--;
            MoveShip();
            break;
        case "down":
            shipRows++;
            MoveShip();
            break;
        case "left":
            shipCols--;
            MoveShip();
            break;
        case "right":
            shipCols++;
            MoveShip();
            break;
        default:
            break;
    }
    if (reachWirpool)
    {
        return;
    }
}
void MoveShip()
{
    if (OutOfBoarders())
    {
        MoveOposite();
        CheckMove();
    }
    CheckMove();
}

void MoveOposite()
{
    if (shipRows < 0)
    {
        shipRows = size - 1;
        CheckMove();
    }
    if (shipCols < 0)
    {
        shipCols = size - 1;
        CheckMove();
    }
    if (shipRows > size - 1)
    {
        shipRows = 0;
        CheckMove();
    }
    if (shipCols > size - 1)
    {
        shipCols = 0;
        CheckMove();
    }
}

void CheckMove()
{
    if (matrix[shipRows,shipCols]=='W')
    {
        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRows},{shipCols}]");
        reachWirpool=true;
    }
}

bool OutOfBoarders()
{
    if (shipRows < 0 || shipCols < 0 || shipRows > size || shipCols > size)
    {
        return true;
    }
    else
    {
        return false;
    }
}