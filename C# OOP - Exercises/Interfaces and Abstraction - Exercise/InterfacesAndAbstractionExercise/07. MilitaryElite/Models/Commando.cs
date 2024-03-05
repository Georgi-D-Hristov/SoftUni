namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using _07._MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Commando : SpecialSolder, ICommando
{
    public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = new List<IMission>();
    }

    public IList<IMission> Missions { get; set; }

    public void AddMissions (IMission mission)
    {
        Missions.Add(mission);
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        foreach (IMission mission in Missions)
        {
            sb.AppendLine($"  {mission.ToString()}");
        }
        return sb.ToString().Trim();
    }
}
