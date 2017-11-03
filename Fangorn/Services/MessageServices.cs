using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Services
{
    
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //TODO: add a mail service here.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            //TODO: add an sms serice.
            return Task.FromResult(0);
        }
    }
}
