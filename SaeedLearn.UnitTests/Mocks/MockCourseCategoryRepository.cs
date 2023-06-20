using Moq;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.UnitTests.Mocks
{
    public static class MockCourseCategoryRepository
    {
        public static Mock<ICourseCategoryRepository> GetCourseCategoryRepository()
        {

            List<CourseCategory> courseCategories = new List<CourseCategory>()
            {
                new CourseCategory()
                {
                    CategoryId = 1,
                    CourseId = 1
                },
                new CourseCategory()
                {
                    CategoryId = 2,
                    CourseId = 2
                }
            };


            var mockRepository = new Mock<ICourseCategoryRepository>();

            mockRepository.Setup(c => c.Add(It.IsAny<CourseCategory>())).ReturnsAsync((CourseCategory courseCategory) =>
                {
                    courseCategories.Add(courseCategory);
                    return courseCategory;
                }
            );

            return mockRepository;
        }
    }
}
