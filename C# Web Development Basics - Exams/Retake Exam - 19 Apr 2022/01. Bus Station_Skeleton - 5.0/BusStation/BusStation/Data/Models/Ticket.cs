namespace BusStation.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        [Key]
        [Required]
        public int Id { get; init; }

        public decimal Price { get; init; }

        
        public string UserId { get; init; }
        
        public User User { get; init; }
        
        public int DestinationId { get; set; }
        
        public Destination Destination { get; init; }
    }
}
