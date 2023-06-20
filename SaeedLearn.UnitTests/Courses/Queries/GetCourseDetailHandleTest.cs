using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Handlers.Queries;
using SaeedLearn.Application.Features.Course.Requests.Queries;
using SaeedLearn.Application.Profiles;
using SaeedLearn.Domain;
using SaeedLearn.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace SaeedLearn.UnitTests.Courses.Queries
{
    public class GetCourseDetailHandleTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICourseRepository> _courseRepository;

        public GetCourseDetailHandleTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _courseRepository = MockCourseRepository.GetCourseRepository();
            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task GetCourseTest()
        {
            var handle = new GetCourseDetailHandle(_courseRepository.Object, _mapper);
            var result = await handle.Handle(new GetCourseDetailRequest(){Id = 1}, CancellationToken.None);
            result.ShouldBeOfType<CourseDto>();
            result.Id.ShouldBe(1);
        }

    }
}
