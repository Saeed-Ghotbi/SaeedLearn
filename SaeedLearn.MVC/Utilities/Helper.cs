namespace SaeedLearn.MVC.Utilities
{
    public static class Helper
    {
        public static void UploadImage(this IFormFile model, string id)
        {
            var pathPicture = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Uploads", "300x150", id + Path.GetExtension(model.FileName));
            using var stream = new FileStream(pathPicture, FileMode.Create);
            model.CopyToAsync(stream);
        }
    }
}
