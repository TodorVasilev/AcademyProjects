using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public interface IEmailsService
    {
        Task SendRegistrationEmail(string email, string template);

       // Task ReSendRegistrationEmail( string email);
    }
}
