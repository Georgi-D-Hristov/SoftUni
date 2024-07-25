namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new List<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
//Id – integer, Primary Key

//· FirstName – text with max length 20 (required)

//· LastName – text with max length 20 (required)

//· Age – integer (required)

//· NetWorth – decimal (required)

//· PerformerSongs – a collection of type SongPerformer