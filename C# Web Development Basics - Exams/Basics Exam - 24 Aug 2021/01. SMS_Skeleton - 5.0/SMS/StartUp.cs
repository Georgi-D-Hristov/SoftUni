namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                .Add<SMSDbContext>()
                .Add<IViewEngine, CompilationViewEngine>())
            .WithConfiguration<SMSDbContext>(context=>context.Database.Migrate())
                .Start();
    }
}