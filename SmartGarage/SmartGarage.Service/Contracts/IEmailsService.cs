using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using System.Threading.Tasks;

namespace SmartGarage.Service.ServiceContracts
{
    public interface IEmailsService
    {
        Task SendRegistrationEmail(string email, string template);

        Task ForgotenPassword(string email, string subject, string url);

        Task RecieveEmail(RecieveEmailViewModel recieveEmailModel);

        Task SendPdfWithOrderDetails(GetOrderDTO order, string email);
    }
}
