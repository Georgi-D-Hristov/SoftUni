namespace _05.FootballGenerator;

using System;

public class Player
{
    private string _name;
    private int _endurance;
    private int _sprint;
    private int _dribble;
    private int _passing;
    private int _shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public int Endurance
    {
        get => _endurance;
        init
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
            }
            _endurance = value;
        }
    }

    public int Sprint

    {
        get => _sprint;
        init
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
            }
            _sprint = value;
        }
    }

    public int Dribble
    {
        get => _dribble;
        init
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
            }
            _dribble = value;
        }
    }

    public int Passing
    {
        get => _passing;
        init
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
            }
            _passing = value;
        }
    }

    public int Shooting
    {
        get => _shooting;
        init
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
            }
            _shooting = value;
        }
    }

    public string Name
    {
        get { return _name; }
        init
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            _name = value;
        }
    }
}

//endurance, sprint, dribble, passing, and shooting