namespace BusStation.Controllers
{
    using BusStation.Data;
    using BusStation.Data.Models;
    using BusStation.Services;
    using BusStation.Services.Users;
    using BusStation.ViewModels.Destinations;
    using BusStation.ViewModels.Tickets;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class TicketsController : Controller
    {
        private readonly BusStationDbContext data;
        private readonly IValidator validator;
        private readonly IUserService userService;

        public TicketsController(
            BusStationDbContext data,
            IValidator validator,
            IUserService userService)
        {
            this.data = data;
            this.validator = validator;
            this.userService = userService;
        }

        [Authorize]
        public HttpResponse Create(int destinationId)
        {
            return View(new TicketCreateViewModel
            {
                DestinationId = destinationId
            });
        }
        [Authorize]
        [HttpPost]
        public HttpResponse Create(TicketCreateFormModel ticketCreate)
        {
            var errorModel = validator.ValidateTikcetsCreate(ticketCreate);
            if (errorModel.Any())
            {
                return Error(errorModel);
            }
            for (int i = 0; i < ticketCreate.TicketsCount; i++)
            {
                var ticket = new Ticket
            {
                Price = ticketCreate.Price,
                //UserId = this.User.Id,
                DestinationId=ticketCreate.DestinationId
            };

          
                 data.Tickets.Add(ticket);
                data.SaveChanges();
            }
            
 
            return Redirect("/Destinations/All");
        }

        [Authorize]
        public HttpResponse MyTickets()
        {
            var tickets = data.Tickets
                .Where(t => t.UserId == this.User.Id)
                .Select(t => t.Destination)
                .Select(d => new TicketsListedViewModel()
                {
                    DestinationName = d.DestinationName,
                    Origin = d.Origin,
                    Time = d.Time,
                    Date = d.Date,
                    ImageUrl = d.ImageUrl,
                    Price = d.Tickets.Select(t => t.Price).First()
                }).ToList();

            return View(tickets);
        }

        [Authorize]
        public HttpResponse Reserve(int destinationId)
        {
            var tickets = data.Tickets
                .Select(t => t.Destination)
                .Where(t=>t.Id==destinationId)
                .Select(d => new TicketsListedViewModel()
                {
                    
                    DestinationName = d.DestinationName,
                    Origin = d.Origin,
                    Time = d.Time,
                    Date = d.Date,
                    ImageUrl = d.ImageUrl,
                    Price = d.Tickets.Select(t => t.Price).First()
                }).ToList();

            return View(tickets);
        }
    }
}
