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
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<TimeService>();
            services.AddTransient<MessageService>();
            services.AddTimeService();
        }

        

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MessageMiddleware>();
            //app.Run(async (context) =>
            //{
            //    MessageService sender =
            //                        context.RequestServices.GetService<MessageService>();
            //    await context.Response.WriteAsync($"<h1>" + sender.SendMessage() + "</h1>");
            //});

        }
    }
}