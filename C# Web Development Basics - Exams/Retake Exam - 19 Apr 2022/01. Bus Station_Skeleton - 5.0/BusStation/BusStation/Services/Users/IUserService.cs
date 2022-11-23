namespace BusStation.Services.Users
{
    using System.Runtime.CompilerServices;

    public interface IUserService
    {
        public string GetUserId(string username, string password);
    }
}
