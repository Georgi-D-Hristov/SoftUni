namespace BusStation.ViewModels.Destinations
{
    using System.ComponentModel;

    public class DestinationsAddFormModel
    {
        public string DestinationName { get; init; }

        public string Origin { get; init; }

        public string Date { get; init; }

        public string Time { get; init; }

        [DisplayName("Image")]
        public string ImageUrl { get; init; }
    }
}
