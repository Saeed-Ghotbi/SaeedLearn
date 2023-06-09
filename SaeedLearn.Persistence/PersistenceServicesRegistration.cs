﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaeedLearn.Application.Contracts.Persistence;
using SaeedLearn.Persistence.Repositories;

namespace SaeedLearn.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SaeedLearnDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SaeedLearnConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
            services.AddScoped(typeof(ICourseCategoryRepository), typeof(CourseCategoryRepository));
            services.AddScoped(typeof(ITeacherRepository), typeof(TeacherRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            return services;
        }
    }
}
