namespace FootballManager
{
    using FootballManager.Data;
    using FootballManager.Services;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<FootballManagerDbContext>()
                .Add<IUserService, UserService>()
                .Add<IValidator, Validator>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
