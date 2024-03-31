namespace NauticalCatchChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PredatoryFish : Fish
    {
        private const int TimeToCatchValue = 60;
        public PredatoryFish(string name, double points)
            : base(name, points, TimeToCatchValue)
        {
        }
    }
}
