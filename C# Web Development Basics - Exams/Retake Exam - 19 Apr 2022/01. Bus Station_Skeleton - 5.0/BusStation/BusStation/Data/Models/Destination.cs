namespace BusStation.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Destination
    {
        [Key]
        [Required]
        public int Id { get; init; }

        public string DestinationName { get; init; }

        public string Origin { get; init; }

        public string Date { get; init; }
        public string Time { get; init; }

        public string ImageUrl { get; init; }

        public IEnumerable<Ticket> Tickets { get; private set; } = new HashSet<Ticket>();
    }
}
