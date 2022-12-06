namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserPlayer
    {
        public string UserId { get; init; }
        public User User { get; init; }

        public int PlayerId { get; init; }
        public Player Player { get; init; }
    }
}
