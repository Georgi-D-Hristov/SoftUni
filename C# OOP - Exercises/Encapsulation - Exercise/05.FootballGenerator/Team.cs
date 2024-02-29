namespace _05.FootballGenerator;

using System;
using System.Collections.Generic;

public class Team
{
    private string _name;
    private readonly List<Player> _players = new();
    private decimal _rating;

    public Team(string name)
    {
        Name = name;
        Rating = 0;
    }

    public decimal Rating
    {
        get { return _rating; }
        set { _rating = value; }
    }

    public IReadOnlyCollection<Player> Players
    {
        get
        {
            return _players.AsReadOnly();
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

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }

    public decimal CalculateRating()
    {
        decimal rating = 0;
        if (_players.Count == 0)
        {
            return 0;
        }
        foreach (Player player in _players)
        {
            rating += player.Endurance + player.Dribble + player.Passing + player.Sprint + player.Shooting;
        }
        rating = rating / (_players.Count * 5);
        decimal result = Math.Round(rating);
        return result;
    }
}