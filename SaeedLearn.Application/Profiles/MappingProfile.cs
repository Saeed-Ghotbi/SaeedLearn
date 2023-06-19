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
            #region Course
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CardCourseDto>().ReverseMap();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>();
            #endregion

            #region Teacher
            CreateMap<Teacher, TeacherDto>();

            #endregion

        }
    }
}
