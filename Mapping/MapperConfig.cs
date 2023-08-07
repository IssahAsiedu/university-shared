using AutoMapper;
using System.Globalization;
using UniversityDto;
using UniversityShared.Models;

namespace UniversityShared.Mapping;


public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Course, CourseCreationData>().ReverseMap();

        CreateMap<Course, CourseResponseData>().ReverseMap();

        CreateMap<Course, CourseCreationData>().ReverseMap();

        CreateMap<Course, CourseUpdateDto>();

        CreateMap<CourseUpdateDto, Course>().ForAllMembers((opt) => opt.Condition((src, dest, value) => value != null));

        CreateMap<Department, DepartmentResponseData>().ReverseMap();

        CreateMap<Course, InstructorCourseResponseData>().ReverseMap();

        CreateMap<Enrollment, InstructorEnrollmentResponseData>().ReverseMap();

        CreateMap<StudentRegistrationData, Student>().ReverseMap();

        CreateMap<Student, StudentRegistrationResponseData>();

        CreateMap<Student, StudentResponseData>().ReverseMap();

        CreateMap<Student, StudentUpdateData>().ForMember((dest) => dest.Courses, (op) => op.MapFrom(s => s.Enrollments));

        CreateMap<StudentUpdateData, Student>()
          .ForAllMembers((opt) => opt.Condition((src, dest, value) => value != null));

        CreateMap<Enrollment, EnrollmentResponseData>().ReverseMap();

        CreateMap<OfficeAssignment, OfficeDto>().ReverseMap();

        CreateMap<Instructor, InstructorDto>().ReverseMap();

        CreateMap<string, DateTime>().ConvertUsing(new StringToDateConverter());

        CreateMap<DateTime, string>().ConvertUsing(new DateToStringConverter());

        CreateMap<Enrollment, string>().ConvertUsing(new EnrollmentToStringConverter());
    }
}

public class EnrollmentToStringConverter : ITypeConverter<Enrollment, string>
{
    public string Convert(Enrollment source, string destination, ResolutionContext context)
    {
        return source.CourseID.ToString();
    }
}

public class StringToDateConverter : ITypeConverter<string, DateTime>
{
    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    {

        bool parsed = DateTime.TryParseExact(source, "yyyy-MM-dd", null, DateTimeStyles.AssumeUniversal, out DateTime result);

        if (!parsed)
        {
            return destination;
        }

        return result;
    }
}

public class DateToStringConverter : ITypeConverter<DateTime, string>
{
    public string Convert(DateTime source, string destination, ResolutionContext context)
    {
        return source.ToString("yyyy-MM-dd");
    }
}