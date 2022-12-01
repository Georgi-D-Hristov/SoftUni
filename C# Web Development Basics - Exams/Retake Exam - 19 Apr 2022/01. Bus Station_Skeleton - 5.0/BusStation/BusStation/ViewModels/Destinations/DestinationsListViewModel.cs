namespace BusStation.ViewModels.Destinations
{
    public class DestinationsListViewModel
    {
        public int Id { get; init; }
        public string DestinationName { get; init; }


        public string Origin { get; init; }


        public string Date { get; init; }


        public string Time { get; init; }

        public string ImageUrl { get; init; }

        public int Tickets { get; init; }
    }
}
