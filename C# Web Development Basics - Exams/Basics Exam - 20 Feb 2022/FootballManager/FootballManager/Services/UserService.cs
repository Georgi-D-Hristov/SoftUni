namespace FootballManager.Services
{
    using FootballManager.Data;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly FootballManagerDbContext data;
        private readonly IPasswordHasher passwordHasher;
        public UserService(FootballManagerDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }
        public string GetUserId(string username, string password)
        {
            var hashedPassword = passwordHasher.GetPasswordHash(password);

            var userId = data.Users
                .Where(u => u.Username == username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }
    }
}
