using FluentValidation;
using SaeedLearn.Application.Contracts.Persistence;

namespace SaeedLearn.Application.DTOs.Course.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public CreateCourseDtoValidator(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("character is not valid");
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("character is not valid");
            RuleFor(c => c.Id)
                .GreaterThan(0);
            RuleFor(c => c.PicturePath).NotNull();
            RuleFor(c => c.TeacherId).MustAsync(async (id, token) =>
            {
                var teacherExist = await _teacherRepository.Exists(id);
                return teacherExist;
            });
        }
    }
}
