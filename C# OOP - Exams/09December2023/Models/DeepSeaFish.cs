namespace NauticalCatchChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeepSeaFish : Fish
    {
        private const int TimeToCatchValue = 180;
        public DeepSeaFish(string name, double points) : base(name, points, TimeToCatchValue)
        {
        }
    }
}
