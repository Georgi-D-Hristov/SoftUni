﻿namespace _07._MilitaryElite.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISpy:ISoldier
{
    int CodeNumber { get; init; }
}
