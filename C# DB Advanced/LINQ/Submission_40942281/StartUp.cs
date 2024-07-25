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
            Console.WriteLine(ExportAlbumsInfo(context, 9));
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
                sb.AppendLine($"-Songs:");
                foreach (var songs in albums.AlbumSongs)
                {
                    sb.AppendLine($"---#{numberOfSong++}");
                    sb.AppendLine($"---SongName: {songs.SongName}");
                    sb.AppendLine($"---Price: {songs.SongPrice:f2}");
                }
                numberOfSong = 1;
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
