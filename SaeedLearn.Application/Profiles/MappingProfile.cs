using AutoMapper;
using SaeedLearn.Application.DTOs.Category;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.DTOs.Teacher;
using SaeedLearn.Domain;

namespace SaeedLearn.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CardCourseDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();

            CreateMap<Teacher, TeacherDto>();
        }
    }
}
