using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Sim.Infrastructure.Identity.Configuration
{
    class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Habilitar o envio de e-mail
            if (false)
            {
                var text = HttpUtility.HtmlEncode(htmlMessage);

                var msg = new MailMessage { From = new MailAddress("admin@portal.com.br", "Admin do Portal") };

                msg.To.Add(new MailAddress(email));
                msg.Subject = subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Html));

                var smtpClient = new SmtpClient("smtp.provedor.com", Convert.ToInt32(587));

                var credentials = new NetworkCredential("ContaDeEmail", "SenhaEmail");

                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }

            return Task.FromResult(0);
        }
    }
}
