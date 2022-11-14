namespace BusStation.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public IEnumerable<Ticket> Tickets { get; private set; } = new HashSet<Ticket>();
    }
}
