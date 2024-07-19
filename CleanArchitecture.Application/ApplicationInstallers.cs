using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationInstallers
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddStackExchangeRedisCache(opts => opts.Configuration = configuration.GetConnectionString("Redis"));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }
    }
}
