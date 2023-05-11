namespace SMS.Data.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        public string Email { get; init; }

        public Cart Cart { get; init; }

        public string CartId { get; init; }
    }
}
