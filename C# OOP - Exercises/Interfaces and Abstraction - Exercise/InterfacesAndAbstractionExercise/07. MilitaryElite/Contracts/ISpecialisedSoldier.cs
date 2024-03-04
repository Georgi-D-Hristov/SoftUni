namespace _07._MilitaryElite.Contracts;

using _07._MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISpecialisedSoldier:IPrivate
{
    Corps Corps { get; set; }
}
