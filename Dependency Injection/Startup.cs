using Dependency_Injection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dependency_Injection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, SmsMessageSender>();
            //services.AddTransient<TimeService>();
            services.AddTimeService();
        }

        public void Configure(IApplicationBuilder app, TimeService time)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<h1>" + time.GetTime() + "</h1>");
            });
        }
    }
}