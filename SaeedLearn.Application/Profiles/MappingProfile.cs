using AutoMapper;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Domain;

namespace SaeedLearn.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
