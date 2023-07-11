using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;

namespace SLVS.Service.Email
{
    public class EmailService : IEmailService
    {
        private readonly IMailjetClient _mailjetClient;

        public EmailService(IMailjetClient mailjetClient)
        {
            _mailjetClient = mailjetClient;
        }

        public async Task SendEmail(string receiver, string subject, string htmlBody)
        {
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            };

            // construct your email with builder
            var emailBuilder = new TransactionalEmailBuilder()
                   .WithFrom(new SendContact("info@siebertmedia.nl"))
                   .WithSubject(subject)
                   .WithHtmlPart(htmlBody)
                   .WithTo(new SendContact(receiver))
                   .Build();

            // invoke API to send email
            var response = await _mailjetClient.SendTransactionalEmailAsync(emailBuilder);
        }
    }
}
