namespace NauticalCatchChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FreeDiver:Diver
    {
        private const int InitialOxugenLevel = 120;
        public FreeDiver(string name) 
            : base(name, InitialOxugenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch*0.60, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = InitialOxugenLevel;
        }
    }
}
