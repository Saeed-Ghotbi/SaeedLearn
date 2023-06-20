using Moq;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Domain;

namespace SaeedLearn.UnitTests.Mocks
{
    public static class MockCourseRepository
    {
        public static Mock<ICourseRepository> GetCourseRepository()
        {
            var course = new Course()
            {
                Id = 1,
                Name = ".net core",
                Price = 1000000,
                ActiveCourse = true,
                Description = ".net core Course",
                Offer = 10,
                TeacherId = 1,
                CourseCategories = new List<CourseCategory>()
                {
                    new CourseCategory()
                    {
                        CategoryId = 2,
                        CourseId = 1
                    }
                },
                DateCreated = DateTime.Now,
                PicturePath = "/images/Uploads/test1.png"
            };
            List<Course> courses = new List<Course>()
            {
                new Course()
                {
                    Id = 2,
                    Name = "js",
                    Price = 200000,
                    ActiveCourse = true,
                    Description = "js Course",
                    Offer = 10,
                    TeacherId = 1,
                    CourseCategories = new List<CourseCategory>()
                    {
                        new CourseCategory()
                        {
                            CategoryId = 1,
                            CourseId = 2
                        }
                    },
                    DateCreated = DateTime.Now,
                    PicturePath = "/images/Uploads/test2.png"
                },
                new Course()
                {
                    Id = 3,
                    Name = "C#",
                    Price = 250000,
                    ActiveCourse = false,
                    Description = "C# Course",
                    Offer = 0,
                    TeacherId = 2,
                    CourseCategories = new List<CourseCategory>()
                    {
                        new CourseCategory()
                        {
                            CategoryId = 2,
                            CourseId = 3
                        }
                    },
                    DateCreated = DateTime.Now,
                    PicturePath = "/images/Uploads/test3.png"
                },
                new Course()
                {
                    Id = 4,
                    Name = "react",
                    Price = 400000,
                    ActiveCourse = true,
                    Description = "React Course",
                    Offer = 20,
                    TeacherId = 1,
                    CourseCategories = new List<CourseCategory>()
                    {
                        new CourseCategory()
                        {
                            CategoryId = 3,
                            CourseId = 4
                        }
                    },
                    DateCreated = DateTime.Now,
                    PicturePath = "/images/Uploads/test4.png"
                }
            };


            var mockRepository = new Mock<ICourseRepository>();
            mockRepository.Setup(s => s.GetCourse(1)).ReturnsAsync(course);
            mockRepository.Setup(s => s.GetCourseList()).ReturnsAsync(courses);
            mockRepository.Setup(c => c.Add(It.IsAny<Course>())).ReturnsAsync((Course course) =>
                {
                    courses.Add(course);
                    return course;
                }
                );

            return mockRepository;
        }
    }
}
