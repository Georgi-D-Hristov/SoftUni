namespace FootballManager.Services
{
    using FootballManager.ViewModels.Players;
    using FootballManager.ViewModels.Users;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using static Data.Models.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidatePlaerAdd(PlayerAddFormModel model)
        {
            var errors = new List<string>();

            if (model.FullName.Length<FullNameMinLength||model.FullName.Length>FullNameMaxLength)
            {
                errors.Add($"Player`s fullname length have to be beetween {FullNameMinLength} and {FullNameMaxLength}!");
            }
            if (model.Position.Length<PositionMinLength||model.Position.Length>PositionMaxLength)
            {
                errors.Add($"Position length have to be beteen {PositionMinLength} and {PositionMaxLength}!");
            }
            if (model.Endurance>EnduranceLimit||model.Endurance<1)
            {
                errors.Add($"The Endurance have to be positive number no bigger then {EnduranceLimit}");
            }
            if (model.Speed > SpeedLimit || model.Speed < 1)
            {
                errors.Add($"The Speed have to be positive number no bigger then {SpeedLimit}");
            }
            if (model.Description.Length>DescriptionMaxLength)
            {
                errors.Add($"The Description lenght have to max {DescriptionMaxLength} characters!");
            }

            return errors;
        }

        public ICollection<string> ValidateUserRegistration(UserRegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < MinUsername || model.Username.Length > MaxUsername)
            {
                errors.Add($"The Username length should be between {MinUsername} and {MaxUsername}!");
            }

            if (model.Email.Length < EmailMinLength || model.Email.Length > EmailMaxLength)
            {
                errors.Add($"The Email length should be between {EmailMinLength} and {EmailMaxLength}");
            }
            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add("Please insert valid Email address!");
            }

            if (model.Password.Length < MinPassword || model.Password.Length > MaxPassword)
            {
                errors.Add($"The password should be between {MinPassword} and {MaxPassword} symbols length.");
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                errors.Add("Please insert valid password!");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"The {nameof(model.Password)} and {nameof(model.ConfirmPassword)} are not equal.");
            }

            return errors;
        }
    }
}
