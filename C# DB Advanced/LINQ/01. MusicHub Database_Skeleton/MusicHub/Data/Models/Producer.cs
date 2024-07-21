namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Producer
    {
        public Producer()
        {
            Albums = new List<Album>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	Name – text with max length 30 (required)
//•	Pseudonym – text
//•	PhoneNumber – text
//•	Albums – a collection of type Album
