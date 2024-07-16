namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        { 
            Resources = new HashSet<Resource>();
            Students = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(80)]
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourse> Students { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
//o CourseId
//o	Name – up to 80 characters, unicode
//o	Description – unicode, not required
//o	StartDate
//o	EndDate
//o	Price
