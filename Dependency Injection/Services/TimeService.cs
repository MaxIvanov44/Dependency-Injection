using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dependency_Injection.Services
{
    public class TimeService
    {
        public string GetTime() => DateTime.Now.ToString("hh:mm:ss");
    }
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient<TimeService>();
        }
    }
    
}