namespace SMS.Data.Models
{
    using SMS.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static Data.DataConstants;

    public class Product
    {
        [Key]
        [Required]
        public string Id { get; init; }=Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Name { get; init; }

        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; init; }

        public Cart Cart { get; init; }

        public string CartId { get; init; }
    }
}
