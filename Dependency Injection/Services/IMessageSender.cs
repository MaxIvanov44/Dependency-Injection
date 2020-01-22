using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Dependency_Injection.Services
{
    public class MessageMiddleware
    {
        
        public MessageMiddleware(RequestDelegate next, MessageService sender)
        {
                
        }
        public async Task InvokeAsync(HttpContext context, MessageService sender)
        {
            await context.Response.WriteAsync(sender.SendMessage());
        }
    }




    public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public string SendMessage()
        {
            return _sender.Send();
        }
    }
    public interface IMessageSender
    {
        string Send();
    }

    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message is sent by email";
        }
    }

    public class SmsMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Message is sent by SMS";
        }
    }
}