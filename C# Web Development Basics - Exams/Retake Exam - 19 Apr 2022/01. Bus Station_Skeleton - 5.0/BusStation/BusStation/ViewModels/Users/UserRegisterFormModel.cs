namespace BusStation.ViewModels.Users
{
    using System.ComponentModel;

    public class UserRegisterFormModel
    {
        public string Username { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        [DisplayName("Repeat Password")]
        public string ConfirmPassword { get; init; }
        
    }
}
