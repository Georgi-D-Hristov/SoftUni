namespace FootballManager.Controllers
{
    using System.Linq;
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Services;
    using FootballManager.ViewModels.Players;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    [Authorize]
    public class PlayersController : Controller
    {
        private readonly IValidator validator;
        private readonly FootballManagerDbContext data;

        public PlayersController(IValidator validator, FootballManagerDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        public HttpResponse All()
        {
            var players = data.Players
                .Select(p => new PlayerListedAllViewModel
                {
                    Id = p.Id,
                    Title = p.Description,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    ImageUrl = p.ImageUrl,
                    Fullname = p.FullName,
                }).ToList();

            return View(players);
        }

        public HttpResponse Collection()
        {
            var isAnyPlayersInCollection = this.data.UserPlayers.Where(up => up.UserId == this.User.Id).Any();

            var playerCollection = this.data.UserPlayers
                .Where(up => up.UserId == this.User.Id)
                .Select(up => up.Player)
                .Select(p => new PlayerListedAllViewModel
                {
                    Id = p.Id,
                    Fullname = p.FullName,
                    Title = p.Description,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                }).ToList();

            return View(playerCollection);
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Add(PlayerAddFormModel model)
        {
            var errorModel = validator.ValidatePlaerAdd(model);
            if (errorModel.Any())
            {
                return Error(errorModel);
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            data.Add(player);
            data.SaveChanges();

            AddPlayerToCollection(player.Id);

            return Redirect("/Players/All");
        }

        public HttpResponse AddToCollection(int playerId)
        {
            var player = data.Players
                .Where(p => p.Id == playerId)
                .FirstOrDefault();

            var user = data.Users.Where(u => u.Id == this.User.Id).First();
            AddPlayerToCollection(playerId);

            return Redirect("/Players/All");
        }

        public HttpResponse RemoveFromCollection(int playerId)
        {
            var removedPlayer = data.UserPlayers
                .Where(up => up.UserId == this.User.Id && up.PlayerId == playerId)
                .First();

            data.UserPlayers.Remove(removedPlayer);
            data.SaveChanges();

            return Redirect("/Players/Collection");
        }

        private void AddPlayerToCollection(int playerId)
        {
            var usersPlayer = new UserPlayer
            {
                UserId = this.User.Id,
                PlayerId = playerId
            };

            if (!data.UserPlayers.Contains(usersPlayer))
            {
                data.UserPlayers.Add(usersPlayer);
                data.SaveChanges();
            }
        }
    }
}
