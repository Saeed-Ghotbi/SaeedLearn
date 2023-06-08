using AutoMapper;
using SaeedLearn.Application.Models.Identity;
using SaeedLearn.MVC.Models;

namespace SaeedLearn.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginViewModel, AuthLogin>().ReverseMap();
            CreateMap<RegisterViewModel, AuthRegister>().ReverseMap();
        }
    }
}
