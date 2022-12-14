namespace FootballManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Player
    {
        [Key]
        [Required]
        public int Id { get; init; }
        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        [MaxLength(PositionMaxLength)]
        public string Position { get; init; }

        [Required]
        [MaxLength(SpeedLimit)]
        public byte Speed { get; init; }

        [Required]
        [MaxLength(EnduranceLimit)]
        public byte Endurance { get; init; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; init; }

        public IEnumerable<UserPlayer> UserPlayers { get; init; } = new HashSet<UserPlayer>();
    }
}
