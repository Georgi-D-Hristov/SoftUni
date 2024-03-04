namespace _07._MilitaryElite.Contracts
{
    using _07._MilitaryElite.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMission
    {
        string CodeName { get; init; }
        State State { get; set; }

        void CompleteMission();
    }
}
