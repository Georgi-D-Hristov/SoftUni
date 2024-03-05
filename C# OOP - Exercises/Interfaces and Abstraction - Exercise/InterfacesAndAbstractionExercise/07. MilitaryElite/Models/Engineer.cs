namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using _07._MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engineer : SpecialSolder, IEngineer
{
    public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<IRepair>();
    }

    public IList<IRepair> Repairs { get; set; }

    public void AddRepairs(IRepair repair)
    {
        Repairs.Add(repair);
    }

    public override string? ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");
        foreach (var pair in Repairs)
        {
            sb.AppendLine($"  {pair.ToString()}");
        }
        return sb.ToString().Trim();
    }
}
