﻿var size = int.Parse(Console.ReadLine());

var matrix = new char[size, size];
var shipRows = -1;
var shipCols = -1;
var reachWirpool = false;
var fishTones = 0;

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
            matrix[shipRows, shipCols] = '-';
            shipRows--;
            MoveShip();
            break;
        case "down":
            matrix[shipRows, shipCols] = '-';
            shipRows++;
            MoveShip();
            break;
        case "left":
            matrix[shipRows, shipCols] = '-';
            shipCols--;
            MoveShip();
            break;
        case "right":
            matrix[shipRows, shipCols] = '-';
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

if (fishTones >= 20)
{
    Console.WriteLine("Success! You managed to reach the quota!");
    PrintHuntTones();
    PrintMatrix();
}
else
{
    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fishTones} tons of fish more.");
    if (fishTones > 0)
    {
        PrintHuntTones();
    }
    PrintMatrix();
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
    if (matrix[shipRows, shipCols] == 'W')
    {
        Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{shipRows},{shipCols}]");
        reachWirpool = true;
    }
    if (matrix[shipRows, shipCols] == '-')
    {
        matrix[shipRows, shipCols] = 'S';
    }
    if (int.TryParse(matrix[shipRows, shipCols].ToString(), out int fish))
    {
        fishTones += fish;
        matrix[shipRows, shipCols] = 'S';

    }
}

void PrintMatrix()
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
        }
        Console.WriteLine();
    }
}

void PrintHuntTones()
{
    Console.WriteLine($"Amount of fish caught: {fishTones} tons.");
}

bool OutOfBoarders()
{
    if (shipRows < 0 || shipCols < 0 || shipRows >= size || shipCols >= size)
    {
        return true;
    }
    else
    {
        return false;
    }
}