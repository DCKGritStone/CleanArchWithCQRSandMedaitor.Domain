using CleanArchWithCQRSandMedaitor.Domain.Repository;
using CleanArchWithCQRSandMediator.Infrastructure.Data;
using CleanArchWithCQRSandMediator.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchWithCQRSandMediator.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BlogConnection") ??
                throw new InvalidOperationException("Connection string 'BlogConnection' not found ")));

            services.AddTransient<IBlogRepository, BlogRepository>();
           return services;
        }
    }
}
