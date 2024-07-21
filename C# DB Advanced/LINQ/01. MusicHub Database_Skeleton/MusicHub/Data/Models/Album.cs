namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}
//Album
//•	Id – integer, Primary Key
//•	Name – text with max length 40 (required)
//•	ReleaseDate – date (required)
//•	Price – calculated property (the sum of all song prices in the album)
//•	ProducerId – integer, foreign key
//•	Producer – the Album's Producer
//•	Songs – a collection of all Songs in the Album 
