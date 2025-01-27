using Freelance.Services;
using Freelance.UOW;

namespace Freelance.Infrastructure.Extensions
{
    public static class DIExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
