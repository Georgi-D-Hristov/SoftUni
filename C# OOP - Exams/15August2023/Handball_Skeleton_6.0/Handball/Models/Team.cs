using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class Team : ITeam
    {
        private string _name;
        private int _pointsEarned;
        private double _overallRating;
        private List<IPlayer> _players;

        public Team(string name)
        {
            Name = name;
            _players = new List<IPlayer>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                _name = value;
            }
        }

        public int PointsEarned
        {
            get => 0;
            private set => _pointsEarned = value;
        }

        public double OverallRating
        {
            get
            {
                if (_players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(_players.Average(p=>p.Rating), 2);
            }
        }

        public IReadOnlyCollection<IPlayer> Players=> _players.AsReadOnly();
      

        public void SignContract(IPlayer player)
        {
            _players.Add(player);
        }

        public void Win()
        {
            _pointsEarned += 3;
            foreach (var player in _players)
            {
                player.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in _players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            PointsEarned += 1;
           var goalKeeper = _players.First(p => p.GetType().Name == typeof(Goalkeeper).Name);
           
           goalKeeper.IncreaseRating();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {_pointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            if (_players.Count!=0)
            {
                sb.AppendLine($"--Players: {string.Join(", ", _players.Select(p=>p.Name).ToList())}");
            }
            else
            {
                sb.Append("--Players: none");
            }

            return sb.ToString().Trim();
        }
    }
}
