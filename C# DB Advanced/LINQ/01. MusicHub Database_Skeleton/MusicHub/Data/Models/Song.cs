namespace MusicHub.Data.Models
{
    using MusicHub.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public DateTime Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public Genre  Genre { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
//integer, Primary Key
// •	Name – text with max length 20 (required)
// •	Duration – TimeSpan (required)
// •	CreatedOn – date (required)
// •	Genre ¬– genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)
// •	AlbumId – integer, Foreign key
// •	Album – the Song's Album
// •	WriterId – integer, Foreign key (required)
// •	Writer – the Song's Writer
// •	Price – decimal (required)
// •	SongPerformers – a collection of type SongPerformer
// 