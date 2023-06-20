using SaeedLearn.Application;
using SaeedLearn.Identity;
using SaeedLearn.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicationService();
builder.Services.ConfigurePersistenceServices(configuration);
builder.Services.ConfigureIdentityServices(configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("SaeedPolicy", b =>
        b.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("SaeedPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
