using System.Net.Mail;
using System.Net;
using OC.Application.Interfaces.Services;
using OC.Validations;
using OC.Libraries.Classes;
using OC.Validations.Errors;

namespace OC.Infra.Services
{
    public class Email : ISendMessage
    {
        public async Task<Validation<string>> Execute(SendMessageClass sendMessageClass)
        {
            try
            {
                using (var smtpClient = new SmtpClient(sendMessageClass.SmtpConfiguration.Server, sendMessageClass.SmtpConfiguration.Port))
                {
                    smtpClient.Credentials = new NetworkCredential(sendMessageClass.Sender, sendMessageClass.SmtpConfiguration.Password);
                    smtpClient.EnableSsl = sendMessageClass.SmtpConfiguration.EnableSSL;

                    using (var mailMessage = new MailMessage(sendMessageClass.Sender, sendMessageClass.Recipient, sendMessageClass.MessageObject.Subject, sendMessageClass.MessageObject.Message))
                    {
                        mailMessage.IsBodyHtml = sendMessageClass.SmtpConfiguration.IsHtml;
                        smtpClient.Send(mailMessage);
                    }
                }

                return Validation<string>.Succeeded();
            }
            catch
            {
                return Validation<string>.Failed(ErrorSendMessage.CannotSendMessage);
            }
        }
    }
}