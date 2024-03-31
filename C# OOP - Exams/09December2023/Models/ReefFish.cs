namespace NauticalCatchChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReefFish : Fish
    {
        private const int TimeToCachValue = 30;
        public ReefFish(string name, double points) 
            : base(name, points, TimeToCachValue)
        {
        }
    }
}
