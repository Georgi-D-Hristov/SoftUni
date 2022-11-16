namespace BusStation.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.User;

    [Index(nameof(Username), IsUnique =true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; init; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; init; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; init; }

        public IEnumerable<Ticket> Tickets { get; private set; } = new HashSet<Ticket>();
    }
}
