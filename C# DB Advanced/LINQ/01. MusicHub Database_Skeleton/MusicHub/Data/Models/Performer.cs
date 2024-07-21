namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Performer
    {
        public Performer()
        {
            
        }
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	FirstName – text with max length 20 (required) 
//•	LastName – text with max length 20 (required) 
//•	Age – integer (required)
//•	NetWorth – decimal (required)
//•	PerformerSongs – a collection of type SongPerformer
