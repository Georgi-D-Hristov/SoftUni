namespace BusStation.Controllers
{
    using BusStation.Data;
    using BusStation.Data.Models;
    using BusStation.Services;
    using BusStation.Services.Users;
    using BusStation.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly BusStationDbContext data;
        private readonly IUserService userService;
        public UsersController(
            IValidator validator,
            BusStationDbContext data,
            IPasswordHasher passwordHasher,
            IUserService userService)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
            this.userService = userService;
        }
        public HttpResponse Register()
        {
            return View();
        }
        [HttpPost]
        public HttpResponse Register(UserRegisterFormModel model)
        {
            var errorModel = validator.ValidateUserRegistration(model);

            if (data.Users.FirstOrDefault(u => u.Username == model.Username) != null)
            {
                errorModel.Add($"Username:{model.Username} is already exists.");
            }
            if (data.Users.FirstOrDefault(u => u.Email == model.Email) != null)
            {
                errorModel.Add($"The email address {model.Email} already exsits");
            }

            if (validator.ValidateUserRegistration(model).Any())
            {
                return Error(errorModel);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = passwordHasher.GetPasswordHash(model.Password)
            };

            data.Users.Add(user);
            data.SaveChanges();

            return Redirect("Login");
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel model)
        {
            var userId = userService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);


            return Redirect("/Destinations/All ");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
