namespace SMS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cart
    {
        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        public User User { get; init; }

        public IEnumerable<Product> Products { get; init; } = new HashSet<Product>();
    }
}
