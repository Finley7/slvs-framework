namespace SLVS.Service.Email
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends an E-mail using the Mailjet API
        /// </summary>
        /// <param name="receiver">The receiver of the message (e-mail)</param>
        /// <param name="subject">The subject of the message</param>
        /// <param name="htmlBody">The (html) body of the message</param>
        /// <returns>nothing if e-mail has been sent</returns>
        public Task SendEmail(string receiver, string subject, string htmlBody);
    }
}
