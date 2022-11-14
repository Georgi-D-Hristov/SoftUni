namespace BusStation.Data.Models
{
    public class Ticket
    {
        public int Id { get; init; }
        public decimal Price { get; private set; }

        public string UserId { get; init; }
        public User User { get; init; }
        public int DestinationId { get; set; }
        public Destination Destination { get; init; }
    }
}
