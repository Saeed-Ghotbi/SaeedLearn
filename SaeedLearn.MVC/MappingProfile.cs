using AutoMapper;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Models.Identity;
using SaeedLearn.MVC.Models;
using SaeedLearn.MVC.Models.Admin;

namespace SaeedLearn.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, AuthLogin>().ReverseMap();
            CreateMap<RegisterViewModel, AuthRegister>().ReverseMap();

            CreateMap<CourseViewModel, CreateCourseDto>().ReverseMap();
            CreateMap<CourseDto, CourseViewModel>()
                .ForMember(dest => dest.CategoryIds,
                opt => opt.MapFrom(
                    src => src.CourseCategories != null ?
                        src.CourseCategories.Select(c => c.CategoryId).ToList() : null))
                .ReverseMap();
            CreateMap<CourseViewModel, UpdateCourseDto>()
                ;
        }
    }
}
