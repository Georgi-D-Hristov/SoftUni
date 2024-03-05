namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

public class LieutenantGeneral : Private, ILieutenantGeneral
{





    public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<IPrivate>();
    }

    public List<IPrivate> Privates { get; }

    public void AddPrivate(Private priv)
    {
        Privates.Add(priv);
    }

    public override string? ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach (IPrivate priv in Privates)
        {
            sb.AppendLine($"  {priv.ToString()}");
        }
        return sb.ToString().Trim();
    }
}
