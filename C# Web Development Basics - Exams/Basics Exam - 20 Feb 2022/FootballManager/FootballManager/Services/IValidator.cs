namespace FootballManager.Services
{
    using FootballManager.ViewModels.Players;
    using FootballManager.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        public ICollection<string> ValidateUserRegistration(UserRegisterFormModel model);
        public ICollection<string> ValidatePlaerAdd(PlayerAddFormModel model);
    }
}
