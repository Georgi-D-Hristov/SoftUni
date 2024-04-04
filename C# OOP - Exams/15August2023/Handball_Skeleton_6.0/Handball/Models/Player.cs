

using Handball.Utilities.Messages;

namespace Handball.Models
{
    using Handball.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Player : IPlayer

    {
        private string _name;
        private double _rating;
        private string _team;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
            
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                _name = value;
            }
        }

        public double Rating
        {
            get => _rating;
            protected set => _rating=value;
        }

        public string Team => _team;

        public void JoinTeam(string name)
        {
            _team=name;
        }

        public abstract void IncreaseRating();


        public abstract void DecreaseRating();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Name}");
            sb.AppendLine($"--Rating: {Rating}");

            return sb.ToString().Trim();
        }
    }
}
