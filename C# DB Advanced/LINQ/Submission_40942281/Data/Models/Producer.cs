namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Producer
    {
        public Producer()
        {
            Albums = new List<Album>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string? Pseudonym { get; set; }

        public string? PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
//Id – integer, Primary Key

//· Name – text with max length 30 (required)

//· Pseudonym – text

//· PhoneNumber – text

//· Albums – a collection of type Album