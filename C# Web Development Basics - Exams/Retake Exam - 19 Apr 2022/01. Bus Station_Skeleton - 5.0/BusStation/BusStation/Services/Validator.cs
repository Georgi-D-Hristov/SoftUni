namespace BusStation.Services
{
    using BusStation.Data;
    using BusStation.ViewModels.Users;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static BusStation.Data.DataConstants.User;

    public class Validator : IValidator
    {
        private readonly BusStationDbContext data;

        public Validator(BusStationDbContext data)
        {
            this.data = data;
        }
        public ICollection<string> ValidateUserRegistration(UserRegisterFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"The Username length should be between {UsernameMinLength} and {UsernameMaxLength}!");
            }

            if (model.Email.Length < EmailMinLength || model.Email.Length > EmailMaxLength)
            {
                errors.Add($"The Email length should be between {EmailMinLength} and {EmailMaxLength}");
            }
            if (!Regex.IsMatch(model.Email, EmailValidationPattern))
            {
                errors.Add("Please insert valid Email address!");
            }

            if (model.Password.Length < PasswordMinLengt || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"The password should be between {PasswordMinLengt} and {PasswordMaxLength} symbols length.");
            }
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"The {nameof(model.Password)} and {nameof(model.ConfirmPassword)} are not equal.");
            }

            return errors;
        }
    }
}
