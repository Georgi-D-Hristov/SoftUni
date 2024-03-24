namespace HighwayToPeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OxygenClimber : Climber
    {
        public OxygenClimber(string name)
            : base(name, stamina: 10)
        {
        }

    }
}
