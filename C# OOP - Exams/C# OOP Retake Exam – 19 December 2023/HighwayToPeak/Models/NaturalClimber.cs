using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NaturalClimber : Climber
    {
        public NaturalClimber(string name)
            : base(name, stamina: 6)
        {
        }

        public override void Climb(IPeak peak)
        {
            if (peak.DifficultyLevel != "Extreme")
            {
                base.Climb(peak);
            }

        }

        public override void Rest(int daysCount)
        {
            Stamina += 2 * daysCount;
        }
    }
}
