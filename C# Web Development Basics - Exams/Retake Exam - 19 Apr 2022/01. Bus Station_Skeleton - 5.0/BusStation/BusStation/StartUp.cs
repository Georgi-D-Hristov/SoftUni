namespace BusStation
{
    using BusStation.Data;
    using BusStation.Services;
    using BusStation.Services.Users;
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
               .Add<BusStationDbContext>()
               .Add<IValidator, Validator>()
               .Add<IPasswordHasher, PasswordHasher>()
               .Add<IUserService, UserService>()
               .Add<IViewEngine, CompilationViewEngine>())
               .WithConfiguration<BusStationDbContext>(context => context
                   .Database.Migrate())
               .Start();
    }
}
