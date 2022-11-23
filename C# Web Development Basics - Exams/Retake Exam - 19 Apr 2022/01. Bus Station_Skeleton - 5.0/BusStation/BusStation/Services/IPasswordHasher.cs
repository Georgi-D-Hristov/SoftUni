namespace BusStation.Services
{
    public interface IPasswordHasher
    {
        public string GetPasswordHash(string password);
    }
}
