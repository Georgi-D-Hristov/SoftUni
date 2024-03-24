namespace HighwayToPeak.Models
{
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private List<string> _conqueredPeaks;

        public Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            _conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Stamina
        {
            get
            {
                return _stamina;
            }
            protected set
            {
                if (value < 0)
                {
                    _stamina = 0;
                }
                else if (value > 10)
                {
                    _stamina = 10;
                }
                _stamina = value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks
        {
            get { return _conqueredPeaks.AsReadOnly(); }
        }

        public virtual void Climb(IPeak peak)
        {
            if (ConqueredPeaks.Contains(peak.Name))
            {
                DecreaseStamina(peak);
            }
            AddConqueredPeak(peak);
            DecreaseStamina(peak);
        }

        public virtual void Rest(int daysCount)
        {
            Stamina += daysCount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (ConqueredPeaks.Count == 0)
            {
                sb.AppendLine($"Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: {ConqueredPeaks.Count}");
            }

            return base.ToString();
        }

        private void DecreaseStamina(IPeak peak)
        {
            switch (peak.DifficultyLevel)
            {
                case "Extreme":
                    Stamina -= 6;
                    break;

                case "Hard":
                    Stamina -= 4;
                    break;

                case "Moderate":
                    Stamina -= 2;
                    break;
            }
        }

        private void AddConqueredPeak(IPeak peak)
        {
            _conqueredPeaks.Add(peak.Name);
        }
    }
}