namespace BusStation.Services
{
    using BusStation.ViewModels.Destinations;
    using BusStation.ViewModels.Tickets;
    using BusStation.ViewModels.Users;
    using System.Collections;
    using System.Collections.Generic;

    public interface IValidator
    {
        public ICollection<string> ValidateUserRegistration(UserRegisterFormModel model);

        public ICollection<string> ValidateDestinationAdd(DestinationsAddFormModel model);

        public ICollection<string> ValidateTikcetsCreate(TicketCreateFormModel model);
    }
}
