namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Private : Solder, IPrivate
{
    public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        Salary=salary;
    }

    public decimal Salary { get; set; }

    public override string? ToString()
    {
        return $"{base.ToString()} {Salary.ToString("f2")}";
    }
}
