namespace BusStation.ViewModels.Tickets
{


    public class TicketsListedViewModel
    {
        public string DestinationName { get; init; }

        public string Origin { get; init; }

        public string Date { get; init; }

        public string Time { get; init; }

        public string ImageUrl { get; init; }

        public decimal Price { get; init; }
    }
}
