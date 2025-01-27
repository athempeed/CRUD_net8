using Freelance.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSettings(this IServiceCollection services,IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidDataException("Connection string not set for the project.");
            }
            services.AddDbContext<FreelancerDBContext>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Singleton);            
        }
    }
}
