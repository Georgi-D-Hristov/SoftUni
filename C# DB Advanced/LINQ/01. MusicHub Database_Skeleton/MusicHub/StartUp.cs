using System.Linq.Expressions;

namespace MusicHub
{
    using Data;
    using Initializer;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            // Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }
    

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var produserAlbumsInfo = context.Producers.First(p => p.Id == producerId)
                .Albums.Select(a => new
                {
                    AlbumName = a.Name,
                    AlbumReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs.Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name,
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriter),
                    TotalAlbumPrice = a.Price
                }).OrderByDescending(a => a.TotalAlbumPrice)
                .ToList();

            var sb = new StringBuilder();
            var numberOfSong = 1;

            foreach (var albums in produserAlbumsInfo)
            {
                sb.AppendLine($"-AlbumName: {albums.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {albums.AlbumReleaseDate}");
                sb.AppendLine($"-ProducerName: {albums.ProducerName}");
                sb.AppendLine($"-Songs:");
                foreach (var songs in albums.AlbumSongs)
                {
                    sb.AppendLine($"---#{numberOfSong++}");
                    sb.AppendLine($"---SongName: {songs.SongName}");
                    sb.AppendLine($"---Price: {songs.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {songs.SongWriter}");
                }

                numberOfSong = 1;
                sb.AppendLine($"-AlbumPrice: {albums.TotalAlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            Func<int, double, bool> predicate = (dura, treshhold) =>
            {
                bool result = false;
                if (dura > treshhold)
                {
                    result = true;
                }

                return result;
            };




            var songsInfo = context.Songs
                .AsEnumerable()
                .Where(s=>s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongWriter = s.Writer.Name,
                    SongPerformer = s.SongPerformers
                        .Select(sp => new
                        {
                            Performer = String.Concat(sp.Performer.FirstName, " ", sp.Performer.LastName)

                        }).OrderBy(sp => sp.Performer),
                    AlbumProducer = s.Album.Producer.Name,
                    SongDuration = s.Duration.ToString("c")

                }).OrderBy(s => s.SongName)
                .ThenBy(s => s.SongWriter)
                .ToList();

            //var resultList = songsInfo.Where(predicate(4, songsInfo.FirstOrDefault(s=>s.SongDuration)));

            var sb = new StringBuilder();
            var songNumber = 1;

            foreach (var song in songsInfo)
            {
                sb.AppendLine($"-Song #{songNumber++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.SongWriter}");
                foreach (var performer in song.SongPerformer)
                {
                    sb.AppendLine($"---Performer: {performer.Performer}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.SongDuration}");
            }

            return sb.ToString().Trim();
        }
    }
    
}
