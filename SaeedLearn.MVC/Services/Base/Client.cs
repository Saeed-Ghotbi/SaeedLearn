using SaeedLearn.Application.DTOs.Course;

namespace SaeedLearn.MVC.Services.Base
{
    public class Client : IClient
    {
        private System.Net.Http.HttpClient _httpClient;
        public HttpClient HttpClient => HttpClient;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CourseGetAll()
        {
            var courses = await _httpClient.GetAsync("api/Course");

            if (courses.IsSuccessStatusCode)
            {
                return await courses.Content.ReadAsStringAsync();
            }

            return "";

        }
    }
}
