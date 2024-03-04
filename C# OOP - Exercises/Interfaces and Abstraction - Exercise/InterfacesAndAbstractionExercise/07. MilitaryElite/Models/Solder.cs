namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Solder : ISoldier
{
    public Solder(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public override string? ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}
