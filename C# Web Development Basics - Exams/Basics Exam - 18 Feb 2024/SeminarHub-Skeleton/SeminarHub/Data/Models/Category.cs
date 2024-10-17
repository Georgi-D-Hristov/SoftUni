using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.ValidationConstants.Category;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public IList<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
//•	Has Id – a unique integer, Primary Key
//•	Has Name – string with min length 3 and max length 50 (required)
//•	Has Seminars – a collection of type Seminar
