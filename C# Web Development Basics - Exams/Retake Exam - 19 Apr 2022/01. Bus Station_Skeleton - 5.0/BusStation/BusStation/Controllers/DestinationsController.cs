namespace BusStation.Controllers
{
    using BusStation.ViewModels.Destinations;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class DestinationsController : Controller
    {
        [Authorize]
        public HttpResponse All()
        {
            return View();
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(DestinationsAddFormModel model) 
        {


            return Redirect("/Destination/All");
        }
    }
}
