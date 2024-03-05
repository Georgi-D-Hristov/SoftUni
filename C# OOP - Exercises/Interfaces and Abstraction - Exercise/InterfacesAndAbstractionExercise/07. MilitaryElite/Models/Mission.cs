namespace _07._MilitaryElite.Models;

using _07._MilitaryElite.Contracts;
using _07._MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mission : IMission
{
    public Mission(string codeName, State state)
    {
        CodeName = codeName;
        State = State.inProgress;
    }

    public string CodeName { get; init; }
    public State State { get; set; }

    public void CompleteMission()
    {
        State = State.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}
