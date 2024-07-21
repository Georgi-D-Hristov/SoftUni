namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game
    {
        public Game()
        {
            Players = new List<Player>();
            PlayersStatistics = new List<PlayerStatistic>();
            Bets = new List<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        public DateTime DateTime { get; set; }

        public Result Result { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }

    public enum Result
    {
        _1,
        X,
        _2

    }
}
//•	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, DateTime, Result
