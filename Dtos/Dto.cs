using System.ComponentModel.DataAnnotations;

namespace UniversityDto;

public record CourseCreationData(
    string Title, 
    string CourseNumber, 
    int Credits, 
    Guid? DepartmentID
);

public record CourseResponseData(
    string ID, 
    string Title, 
    string CourseNumber, 
    string Credits, 
    Guid? DepartmentID, 
    DepartmentResponseData Department
);

public record InstructorCourseResponseData(
    string ID, 
    string Title, 
    string CourseNumber, 
    string Credits, 
    Guid? DepartmentID, 
    DepartmentResponseData Department,
    List<InstructorEnrollmentResponseData> Enrollments
);

public record InstructorRegistrationData
{
    [Required]
    [MinLength(3)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string? HireDate { get; set; }

    public List<string> Courses { get; set; } = new();

    public string? Office { get; set; } 
}

public record InstructorUpdateData
{
    [MinLength(3)]
    public string? LastName { get; set; } = string.Empty;

    [MinLength(3)]
    public string? FirstName { get; set; } = string.Empty;

    [MinLength(3)]
    public string? HireDate { get; set; }

    public List<string> Courses { get; set; } = new();

    public string? Office { get; set; }
}

public record CourseUpdateDto
{
    public string? Title { get; set; }

    public string? CourseNumber { get; set; }

    public int? Credits { get; set; }

    public Guid DepartmentID { get; set; }
}

public record InstructorDto
{
    public string ID { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string HireDate { get; set; } = string.Empty;

    public List<InstructorCourseResponseData> Courses { get; set; } = new();

    public OfficeDto? OfficeAssignment { get; set; }
}

public record OfficeDto
{
    public string Location { get; set; } = string.Empty;
}

public record DepartmentResponseData(string DepartmentID, string Name);

public record EnrollmentData([Required] Guid StudentID, [Required] Guid CourseID);

public record StudentRegistrationData (
    [Required, MinLength(1)]
    string FirstName,
    [Required, MinLength(1)]
    string LastName,
    [Required, RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
    string EnrollmentDate
);

public record StudentUpdateData
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EnrollmentDate { get; set; }

    public List<string> Courses { get; set; } = new List<string>();

    public bool UpdateProvided()
    {
        return FirstName != null || LastName != null || EnrollmentDate != null;
    }
}

public record StudentRegistrationResponseData(
    string ID,
    string FirstName,
    string LastName,
    string EnrollmentDate
);

public record StudentResponseData(
    string ID,
    string FirstName,
    string LastName,
    string EnrollmentDate,
    List<EnrollmentResponseData> Enrollments
);

public record StudentGradingData(
    [Required] Guid CourseID,
    [Required] Guid StudentID,
    [Required] string Grade
);

public record EnrollmentResponseData(
    string ID,
    string? Grade,
    CourseResponseData? Course
);

public record InstructorEnrollmentResponseData(
    string ID,
    string? Grade,
    CourseResponseData? Course,
    StudentResponseData? Student
);

public record PaginationFilter
{
    private int? index;

    private int? pageSize;

    public int CurrentIndex { get => index ?? 1; set => index = value; }

    public int PageSize { get => pageSize ?? 10; set => pageSize = value; }
}

public record PaginationResponseData
{
    public int CurrentIndex { get; set; }

    public int Count { get; set; }
}

public record StudentPaginationData(List<StudentResponseData> Students): PaginationResponseData;

public record CoursePaginationData(List<CourseResponseData> Courses): PaginationResponseData;
public record InstructorPaginationData(List<InstructorDto> Instructors): PaginationResponseData;