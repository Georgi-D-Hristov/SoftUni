namespace _07._MilitaryElite.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICommando:ISpecialisedSoldier
{
    IEnumerable<IMission> Missions { get; }
}
