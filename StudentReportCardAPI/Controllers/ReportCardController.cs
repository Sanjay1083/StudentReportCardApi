using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentReportCardAPI.Data;

namespace StudentReportCardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportCardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("GetReportCards")]
        public IActionResult GetReportCards([FromBody] List<int> studentIds)
        {
            if (studentIds == null || studentIds.Count == 0)
                return BadRequest("No student IDs provided.");

            var students = _context?.Students?
                .Where(s => studentIds.Contains(s.StudentId))
                .Include(s => s.StudentMarks)
                    .ThenInclude(sm => sm.Subject)
                        .ThenInclude(sub => sub!.Exam)
                .ToList();

            if (!students!.Any())
                return NotFound("No students found for the provided IDs.");

            var result = students!.Select(student => new
            {
                student.Name,
                student.ClassName,
                student.SectionName,
                student.AcademicYear,
                Exams = student?.StudentMarks?
                    .GroupBy(m => m.Subject?.Exam)
                    .Select(examGroup => new
                    {
                        ExamId = examGroup?.Key?.ExamId,
                        ExamName = examGroup?.Key?.Name,
                        Subjects = examGroup?.Select(m => new
                        {
                            SubjectId = m.Subject?.SubjectId,
                            SubjectName = m.Subject?.Name,
                            MarksObtained = m.MarksObtained,
                            MaxMarks = m.MaxMarks
                        }),
                        TotalObtained = examGroup?.Sum(m => m.MarksObtained),
                        TotalMax = examGroup?.Sum(m => m.MaxMarks),
                        Percentage = Math.Round(
                            examGroup!.Sum(m => m.MarksObtained) * 100.0 / examGroup!.Sum(m => m.MaxMarks), 2)
                    })
            });

            return Ok(new
            {
                message = "Successfully fetched report cards.",
                data = result

            });
        }
    }
}