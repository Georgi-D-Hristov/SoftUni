﻿namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        public Player()
        {
            PlayersStatistics = new List<PlayerStatistic>();    
        }

        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }
        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    }
}
//•	Player – PlayerId, Name, SquadNumber, IsInjured, PositionId , TeamId, TownId 