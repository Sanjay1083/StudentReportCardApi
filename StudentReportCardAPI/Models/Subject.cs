using System.ComponentModel.DataAnnotations;

namespace StudentReportCardAPI.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; } // ✅ Clear primary key
        public string? Name { get; set; }

        public int ExamId { get; set; } // ✅ Foreign key
        public Exam? Exam { get; set; }
    }

}
