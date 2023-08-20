namespace SaeedLearn.MVC.Services.Base
{
    public interface IClient
    {
        public HttpClient HttpClient { get; }
        public Task<string> CourseGetAll();
    }
}
