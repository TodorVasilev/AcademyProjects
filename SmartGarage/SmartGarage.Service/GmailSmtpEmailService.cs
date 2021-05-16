using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class GmailSmtpEmailsService : IEmailsService
    {
        private const string fromEmail = "DummyEmail1886@gmail.com";
        private readonly string password = "A123123123a";

        //public async Task ReSendRegistrationEmail(string email)
        //{
        //        var message = new MailMessage(FROM_EMAIL, email, "New confirmation email from Life Mode", $"{url}/auth/confirmEmail/{email}&{token}");
        //        message.IsBodyHtml = true;
        //        await _smtpClient.SendMailAsync(message);
        //}

        public async Task SendRegistrationEmail(string email, string userPassword)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(email);
                mail.Subject = "New confirmation email with a login password";
                mail.Body = "Confirmation password " + userPassword + "<a href= 'https://localhost:5001/Identity/Account/Login' > Configuration link </ a > ";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, password);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            //message.AlternateViews.Add(GetEmbeddedImage("./Images/logo_transparent.png", template, token));
        }

        private AlternateView GetEmbeddedImage(String filePath, string template)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentType = new ContentType()
            {
                MediaType = "image/png",
                Name = "logo_transparent.png"
            };
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = string.Format(template, res.ContentId);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}