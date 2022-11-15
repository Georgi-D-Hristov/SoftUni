namespace BusStation.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Destination
    {
        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(50)]
        public string DestinationName { get; init; }

        [Required]
        [MaxLength(50)]
        public string Origin { get; init; }

        [Required]
        [MaxLength(30)]
        public string Date { get; init; }

        [Required]
        [MaxLength(30)]
        public string Time { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        public IEnumerable<Ticket> Tickets { get; private set; } = new HashSet<Ticket>();
    }
}
