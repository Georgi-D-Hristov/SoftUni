namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxUsername)]
        public string Username { get; init; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; init; }

        [Required]
        [MaxLength(MaxPassword)]
        public string Password { get; init; }

        public IEnumerable<UserPlayer> UserPlayers { get; init; } = new HashSet<UserPlayer>();
    }
}
