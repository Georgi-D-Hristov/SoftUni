namespace Panda.Web.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public RoleManager<User> Role { get; init; }

        public int MyProperty { get; set; }
    }
}
