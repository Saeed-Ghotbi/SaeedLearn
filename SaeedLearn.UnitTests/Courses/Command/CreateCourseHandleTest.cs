using AutoMapper;
using Moq;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Application.DTOs.Course;
using SaeedLearn.Application.Features.Course.Handlers.Command;
using SaeedLearn.Application.Features.Course.Requests.Command;
using SaeedLearn.Application.Profiles;
using SaeedLearn.Application.Responses;
using SaeedLearn.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace SaeedLearn.UnitTests.Courses.Command
{
    public class CreateCourseHandleTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICourseRepository> _courseRepository;
        private readonly Mock<ICourseCategoryRepository> _courseCategoryRepository;
        private readonly CreateCourseDto _createCourseDto;
        public CreateCourseHandleTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _courseRepository = MockCourseRepository.GetCourseRepository();
            _courseCategoryRepository = MockCourseCategoryRepository.GetCourseCategoryRepository();
            _mapper = mapperConfig.CreateMapper();
            _createCourseDto = new CreateCourseDto()
            {
                Id = 5,
                Name = "new course",
                Price = 100000,
                TeacherId = 1,
                PicturePath = "/images/Uploads/TestCreate.png",
                Description = "new course description",
                CategoryIds = new List<int>() { 1, 2, 3 },
                ActiveCourse = false,
                Offer = 10,
                DateCreated = DateTime.Now
            };
        }

        [Fact]
        public async Task CreateCourseTest()
        {
            var handle = new CreateCourseHandle(_mapper, _courseCategoryRepository.Object, _courseRepository.Object);

            var result = await handle.Handle(new CreateCourseRequest() { CreateCourseDto = _createCourseDto },
                CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(true);
            result.Id.ShouldBe(5);
        }
    }
}
