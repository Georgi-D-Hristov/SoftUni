namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }

    public enum Prediction
    {
        _1,
        X,
        _2
    }
}
//•	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId