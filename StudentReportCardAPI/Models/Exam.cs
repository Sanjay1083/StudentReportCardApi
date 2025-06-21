using System.ComponentModel.DataAnnotations;

namespace StudentReportCardAPI.Models
{
    public class Exam
    {

        [Key]
        public int ExamId { get; set; }
        public string? Name { get; set; }

        public List<Subject>? Subjects { get; set; }
    }

}
