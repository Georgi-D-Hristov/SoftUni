namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            Courses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName ="NVARCHAR")]
        public string Name { get; set; }

        [Column(TypeName ="CHAR(10)")]
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
//o StudentId
//o	Name – up to 100 characters, unicode
//o	PhoneNumber – exactly 10 characters, not unicode, not required
//o	RegisteredOn
//o	Birthday – not required
