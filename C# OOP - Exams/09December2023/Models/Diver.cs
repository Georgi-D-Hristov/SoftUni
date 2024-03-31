using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Diver : IDiver
    {
        private string _name;
        private int _oxygenLevel;
        private HashSet<string> _catch;
        private double _competitionPoints;
        private bool _hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            _catch = new HashSet<string>();
            CompetitionPoints = 0;
            HasHealthIssues = false;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                _name = value;
            }
        }

        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get => _catch;

        }

        public double CompetitionPoints
        {
            get => _competitionPoints;
            private set
            {
                _competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get => _hasHealthIssues;
            private set
            {
                _hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            _catch.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);




        public void UpdateHealthStatus()
        {
            if (HasHealthIssues)
            {
                HasHealthIssues=false;
            }
            else
            {
                HasHealthIssues=true;
            }
        }

        public abstract void RenewOxy();

        public override string ToString()
        {
            return base.ToString();
            {
                return
                    $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
            }
        }
    }
}
