namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price => Songs.Sum(s => s.Price);

        public int? ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
//Id – integer, Primary Key

//· Name – text with max length 40 (required)

//· ReleaseDate – date (required)

//· Price – calculated property (the sum of all song prices in the album)

//· ProducerId – integer, foreign key

//· Producer – the Album's Producer

//· Songs – a collection of all Songs in the Album