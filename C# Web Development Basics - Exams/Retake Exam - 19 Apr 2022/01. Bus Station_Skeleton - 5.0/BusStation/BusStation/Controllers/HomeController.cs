namespace BusStation.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return View();
        }
    }
}
