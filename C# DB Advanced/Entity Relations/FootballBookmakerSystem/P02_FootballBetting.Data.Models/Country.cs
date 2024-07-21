namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Country
    {
        [Key] 
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
//•	Country – CountryId, Name