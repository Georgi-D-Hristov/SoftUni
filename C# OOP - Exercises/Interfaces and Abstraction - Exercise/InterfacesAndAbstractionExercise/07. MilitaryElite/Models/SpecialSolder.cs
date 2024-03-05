namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using _07._MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class SpecialSolder : Solder, ISpecialisedSoldier
{
    protected SpecialSolder(int id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName)
    {
        Salary = salary;
        Corps = corps;
    }

    public Corps Corps { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {Corps}");
        return sb.ToString().Trim();
    }
}
