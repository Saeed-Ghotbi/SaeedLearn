using SaeedLearn.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaeedLearn.Application.DTOs.Course.Validators
{
    public class UpdateCourseDtoValidator 
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseDtoValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            //RuleFor(c => c.TeacherId).MustAsync(async (id, token) =>
            //{
            //    var teacherExist = await _teacherRepository.Exists(id);
            //    return teacherExist;
            //});
        }

    }
}
