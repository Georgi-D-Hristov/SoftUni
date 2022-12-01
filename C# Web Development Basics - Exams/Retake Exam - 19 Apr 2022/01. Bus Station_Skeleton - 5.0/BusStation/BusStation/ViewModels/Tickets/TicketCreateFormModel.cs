namespace BusStation.ViewModels.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TicketCreateFormModel
    {
        public decimal Price { get; init; }

        public int TicketsCount { get; init; }

        public string UserId { get; init; }

        public int DestinationId { get; init; }
    }
}
