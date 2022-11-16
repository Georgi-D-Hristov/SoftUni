namespace BusStation.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Destination;

    public class Destination
    {
        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string DestinationName { get; init; }

        [Required]
        [MaxLength(OriginMaxLength)]
        public string Origin { get; init; }

        [Required]
        [MaxLength(DateTimeMaxLength)]
        public string Date { get; init; }

        [Required]
        [MaxLength(DateTimeMaxLength)]
        public string Time { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        public IEnumerable<Ticket> Tickets { get; private set; } = new HashSet<Ticket>();
    }
}
