using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Sim.Infrastructure.Identity.Configuration
{
    public class SmsService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
