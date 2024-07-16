namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resource
    {
        [Key] 
        public int ResourceId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName ="NVARCHAR")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
public enum ResourceType
{
    Video, 
    Presentation,
    Document,
    Other
}

//o ResourceId
//o	Name – up to 50 characters, unicode
//o	Url – not unicode
//o	ResourceType – enum, can be Video, Presentation, Document or Other
//o	CourseId
