namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Position
    {
        public Position()
        {
                Players = new List<Player>();
        }

        [Key]
        public int PositionId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
//•	Position – PositionId, Name
