namespace BusStation.Controllers
{
    using BusStation.Data;
    using BusStation.Data.Models;
    using BusStation.Services;
    using BusStation.ViewModels.Destinations;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class DestinationsController : Controller
    {
        private readonly BusStationDbContext data;
        private readonly IValidator validator;

        public DestinationsController(BusStationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var destinations = data.Destinations
                .Select(d => new DestinationsListViewModel
                {
                    DestinationName = d.DestinationName,
                    Origin = d.Origin,
                    Date = d.Date,
                    Time = d.Time,
                    ImageUrl = d.ImageUrl,
                    Tickets=d.Tickets.Count()
                })
                .ToList();

            return View(destinations);
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
            var errorsModel = validator.ValidateDestinationAdd(model);

            if (errorsModel.Any())
            {
                return Error(errorsModel);
            }

            var dateTimeArgs = model.Date.Split('T').ToArray();
            var date = DateTime.Parse(dateTimeArgs[0]).ToString("d", DateTimeFormatInfo.InvariantInfo);
            var time = DateTime.Parse(dateTimeArgs[1]).ToString("hh:mm:tt", DateTimeFormatInfo.InvariantInfo);

            var destination = new Destination
            {
                DestinationName = model.DestinationName,
                Origin = model.Origin,
                Date = date,
                Time = time,
                ImageUrl = model.ImageUrl
            };

            data.Destinations.Add(destination);
            data.SaveChanges();

            return Redirect("/Destinations/All");
        }
    }
}
