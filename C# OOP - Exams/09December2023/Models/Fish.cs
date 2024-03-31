using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public abstract class Fish : IFish
    {
        private const double MinPoints = 1;
        private const double MaxPoints = 10;

        private Regex regex = new Regex(@"^[0-9]+(\.[0-9]{1})?$");

        private string _name;
        private double _points;
        private int _timeToCatch;

        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points= points;
            TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                _name = value;
            }
        }

        public double Points
        {
            get => _points;

            private set
            {
                if (value < MinPoints || value > MaxPoints)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
            }
        }

        public int TimeToCatch
        {
            get =>_timeToCatch;
            private set
            {
                _timeToCatch = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
