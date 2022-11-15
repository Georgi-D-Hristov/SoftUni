namespace BusStation.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [Index(nameof(Username), IsUnique =true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public IEnumerable<Ticket> Tickets { get; private set; } = new HashSet<Ticket>();
    }
}
