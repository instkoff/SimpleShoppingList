using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimpleShoppingList.DataAccess;

namespace SimpleShoppingList.Web
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services
                .AddScoped<IDbRepository, EfRepository>(provider =>
                    new EfRepository(provider.GetRequiredService<DataContext>()));
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple Shopping List", Version = "v1" });
            });
            return services;
        }
    }
}
