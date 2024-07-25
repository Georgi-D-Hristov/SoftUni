namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; }
        public Song Song { get; set; }

        public int PerformerId { get; set; }

        public Performer Performer { get; set; }
    }
}
//SongId – integer, Primary Key

//· Song – the performer's Song (required)

//· PerformerId – integer, Primary Key

//· Performer – the Song's Performer (required)