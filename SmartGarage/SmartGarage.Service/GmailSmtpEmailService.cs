using SmartGarage.Service.ServiceContracts;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class GmailSmtpEmailsService : IEmailsService
    {
        private const string fromEmail = "DummyEmail1886@gmail.com";
        private const string password = "A123123123a";

        //Sends an E-mail to the user with random generated password.
        public async Task SendRegistrationEmail(string email, string userPassword)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(email);
                mail.Subject = "New confirmation email with a login password";
                mail.Body = "Confirmation password " + userPassword + "<a href= 'https://localhost:5001/Identity/Account/Login' > Login page: https://localhost:5001/Identity/Account/Login </ a > ";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, password);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}