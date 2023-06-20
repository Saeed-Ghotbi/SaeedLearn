using AutoMapper;
using Moq;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Handlers.Queries;
using SaeedLearn.Application.Features.Course.Requests.Queries;
using SaeedLearn.Application.Profiles;
using SaeedLearn.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace SaeedLearn.UnitTests.Courses.Queries
{
    public class GetCourseListHandleTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICourseRepository> _courseRepository;

        public GetCourseListHandleTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _courseRepository = MockCourseRepository.GetCourseRepository();
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCourseListTest()
        {
            var handle = new GetCourseListHandle(_courseRepository.Object, _mapper);
            var result = await handle.Handle(new GetCourseListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<CourseDto>>();
            result.Count.ShouldBe(3);

        }

    }
}
