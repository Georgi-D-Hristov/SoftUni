﻿namespace BusStation.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("Destinations/All");
            }
            return View();
        }
    }
}
