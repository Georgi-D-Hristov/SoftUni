namespace _07._MilitaryElite.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICommando:ISpecialisedSoldier
{
    IList<IMission> Missions { get; set; }
}
