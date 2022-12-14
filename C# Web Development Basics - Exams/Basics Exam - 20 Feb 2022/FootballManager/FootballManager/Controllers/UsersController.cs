namespace FootballManager.Controllers
{
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Services;
    using FootballManager.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserService userService;

        public UsersController(FootballManagerDbContext data, IValidator validator, IPasswordHasher passwordHasher, IUserService userService)
        {
            this.data = data;
            this.validator = validator;
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
                errorModel.Add($"Username: {model.Username} is already exists.");
            }
            if (data.Users.FirstOrDefault(u => u.Email == model.Email) != null)
            {
                errorModel.Add($"The email address {model.Email} already exsits");
            }

            if (errorModel.Any())
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


            return Redirect("/Players/All ");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }

}
