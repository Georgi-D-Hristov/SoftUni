namespace Fluffy_Duffy_Munchkin_Cats_WebApp.Models.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name should be between {1} and {0}.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public int Age { get; set; }

        public string Breed { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}
