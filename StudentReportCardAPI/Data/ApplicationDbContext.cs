using Microsoft.EntityFrameworkCore;
using StudentReportCardAPI.Models;

namespace StudentReportCardAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentMark> StudentMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Ravi", ClassName = "10", SectionName = "A", AcademicYear = "2024-25" },
                new Student { StudentId = 2, Name = "Priya", ClassName = "10", SectionName = "B", AcademicYear = "2024-25" },
                new Student { StudentId = 3, Name = "Karthik", ClassName = "9", SectionName = "C", AcademicYear = "2024-25" },
                new Student { StudentId = 4, Name = "Sneha", ClassName = "8", SectionName = "A", AcademicYear = "2024-25" },
                new Student { StudentId = 5, Name = "Manoj", ClassName = "10", SectionName = "C", AcademicYear = "2024-25" }
            );

            // Exams
            modelBuilder.Entity<Exam>().HasData(
                new Exam { ExamId = 1, Name = "Midterm" },
                new Exam { ExamId = 2, Name = "Final" }
            );

            // Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Name = "Math", ExamId = 1 },
                new Subject { SubjectId = 2, Name = "Science", ExamId = 1 },
                new Subject { SubjectId = 3, Name = "Math", ExamId = 2 },
                new Subject { SubjectId = 4, Name = "Science", ExamId = 2 }
            );

            // Student Marks for ALL 5 students
            modelBuilder.Entity<StudentMark>().HasData(
                // Ravi - StudentId 1
                new StudentMark { StudentMarkId = 1, StudentId = 1, SubjectId = 1, MarksObtained = 45, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 2, StudentId = 1, SubjectId = 2, MarksObtained = 40, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 3, StudentId = 1, SubjectId = 3, MarksObtained = 48, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 4, StudentId = 1, SubjectId = 4, MarksObtained = 47, MaxMarks = 50 },

                // Priya - StudentId 2
                new StudentMark { StudentMarkId = 5, StudentId = 2, SubjectId = 1, MarksObtained = 42, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 6, StudentId = 2, SubjectId = 2, MarksObtained = 38, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 7, StudentId = 2, SubjectId = 3, MarksObtained = 46, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 8, StudentId = 2, SubjectId = 4, MarksObtained = 44, MaxMarks = 50 },

                // Karthik - StudentId 3
                new StudentMark { StudentMarkId = 9, StudentId = 3, SubjectId = 1, MarksObtained = 40, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 10, StudentId = 3, SubjectId = 2, MarksObtained = 42, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 11, StudentId = 3, SubjectId = 3, MarksObtained = 39, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 12, StudentId = 3, SubjectId = 4, MarksObtained = 45, MaxMarks = 50 },

                // Sneha - StudentId 4
                new StudentMark { StudentMarkId = 13, StudentId = 4, SubjectId = 1, MarksObtained = 48, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 14, StudentId = 4, SubjectId = 2, MarksObtained = 46, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 15, StudentId = 4, SubjectId = 3, MarksObtained = 47, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 16, StudentId = 4, SubjectId = 4, MarksObtained = 49, MaxMarks = 50 },

                // Manoj - StudentId 5
                new StudentMark { StudentMarkId = 17, StudentId = 5, SubjectId = 1, MarksObtained = 44, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 18, StudentId = 5, SubjectId = 2, MarksObtained = 43, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 19, StudentId = 5, SubjectId = 3, MarksObtained = 46, MaxMarks = 50 },
                new StudentMark { StudentMarkId = 20, StudentId = 5, SubjectId = 4, MarksObtained = 47, MaxMarks = 50 }
            );
        }

    }
}