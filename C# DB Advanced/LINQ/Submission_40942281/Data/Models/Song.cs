namespace MusicHub.Data.Models
{
    using MusicHub.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Song
    {
        public Song()
        {
            SongPerformers = new List<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }

        public int WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public Writer Writer { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
//Song

//· Id – integer, Primary Key

//· Name – text with max length 20 (required)

//· Duration – TimeSpan (required)

//· CreatedOn – date (required)

//· Genre – genreenumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz"(required)

//· AlbumId – integer, Foreign key

//· Album – the Song's Album

//· WriterId – integer, Foreign key

//· Writer – the Song's Writer

//· Price – decimal (required)

//· SongPerformers – a collection of type SongPerformer