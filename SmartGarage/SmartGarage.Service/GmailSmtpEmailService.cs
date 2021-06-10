using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using SmartGarage.Service.ServiceContracts;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
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
            var sb = new StringBuilder();
            sb.AppendLine($"<div><h3>Confirmation password: { userPassword } <h3></div>");
            sb.AppendLine("<br>");
            sb.AppendLine("<h3>Login page: <a href= 'https://localhost:5001/Identity/Account/Login'> https://localhost:5001/Identity/Account/Login </h3></ a >");

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(email);
                mail.Subject = "New confirmation email with a login password";
                mail.Body = sb.ToString();
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

        public async Task SendPdfWithOrderDetails(GetOrderDTO order, string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(email);
                mail.Subject = $"Your car is ready for pickup {DateTime.Now.ToString("dd-MM-yyyy")}";
                mail.Body = "PDF";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, password);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = true;
                    mail.Attachments.Add(new Attachment(await new PdfService().GeneratePdf(order), "OrderDetails.pdf"));
                    await smtp.SendMailAsync(mail);
                }
            }
        }

        public async Task RecieveEmail(RecieveEmailViewModel recieveEmailModel)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<div><h3>Person Name: {recieveEmailModel.PersonName}</h3></div>");
            sb.AppendLine($"<div><h3>Person E-mail: {recieveEmailModel.PersonEmail}</h3></div>");
            sb.AppendLine($"<div><h3>Person Number: {recieveEmailModel.PhoneNumber}</h3></div>");
            sb.AppendLine($"<div style=\"margin-left:685px;\"><h2>Message: </h2></div>");
            sb.AppendLine($"<hr>");
            sb.AppendLine($"<div style=\"margin-left:285px; width:800px; \"><h3>{recieveEmailModel.Message}</h3></div>");
            sb.AppendLine($"<hr>");

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(recieveEmailModel.PersonEmail);
                mail.To.Add(fromEmail);
                mail.Subject = "New message";
                mail.Body = sb.ToString();
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

        public async Task ForgotenPassword(string email, string subject, string url)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = url;
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