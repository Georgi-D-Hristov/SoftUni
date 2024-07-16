namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        public int CourseId { get; set; }


        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}

public enum ContentType
{
    Application, 
    Pdf, 
    Zip
}
//o HomeworkId
//o	Content – string, linking to a file, not unicode
//o	ContentType - enum, can be Application, Pdf or Zip
//o	SubmissionTime
//o	StudentId
//o	CourseId
