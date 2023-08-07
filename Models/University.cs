using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityShared.Models;


public class Course
{
    public Guid ID { get; set; }

    [Required, MinLength(2)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Credits { get; set; }

    public string CourseNumber { get; set; } = string.Empty;

    public Guid DepartmentID { get; set; }

    public Department? Department { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}

public enum Grade
{
    A, B, C, D, F
}

public class Enrollment
{
    public Guid ID { get; set; }

    public Guid CourseID { get; set; }

    public Guid StudentID { get; set; }

    public Grade? Grade { get; set; }

    public Course? Course { get; set; }

    public Student? Student { get; set; }
}

public class Student
{
    public Guid ID { get; set; } = Guid.Empty;

    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;

    [MinLength(3)]
    public string LastName { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

}

public class Instructor
{
    public Guid ID { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }

    [Required]
    [StringLength(50)]
    public required string FirstName { get; set; }

    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }

    public List<Course> Courses { get; set; } = new List<Course>();

    public OfficeAssignment? OfficeAssignment { get; set; }
}

public class OfficeAssignment
{
    [Key]
    public Guid InstructorID { get; set; }

    [StringLength(50)]
    public string Location { get; set; } = string.Empty;

    public Instructor? Instructor { get; set; }
}

public class Department
{
    public Guid DepartmentID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public required string Name { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    public decimal Budget { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    public Guid? InstructorID { get; set; }

    public Instructor? Administrator { get; set; }

    public List<Course> Courses { get; set; } = new List<Course>();  
}