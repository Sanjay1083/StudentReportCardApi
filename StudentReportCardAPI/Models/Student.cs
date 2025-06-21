using System.ComponentModel.DataAnnotations;

namespace StudentReportCardAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } 
        public string? Name { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? AcademicYear { get; set; }

        public List<StudentMark>? StudentMarks { get; set; }
    }

}
