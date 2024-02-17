using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
                                                                    IConfiguration config) 
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();

            // Data Mapper services
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Cloudinary service
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            // Add repositories services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IPhotoService, PhotoService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
