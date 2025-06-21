using System.ComponentModel.DataAnnotations;

namespace StudentReportCardAPI.Models
{
    public class StudentMark
    {

        [Key]
        public int StudentMarkId { get; set; } 

        public int StudentId { get; set; } 
        public Student? Student { get; set; }

        public int SubjectId { get; set; } 
        public Subject? Subject { get; set; }

        public int MarksObtained { get; set; }
        public int MaxMarks { get; set; }
    }
}
