namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Writer
    {
        public Writer()
        {
            Songs = new List<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public string? Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
//Id – integer, Primary Key

//· Name – text with max length 20 (required)

//· Pseudonym – text

//· Songs – a collection of type Song