namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solder : ISoldier
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
