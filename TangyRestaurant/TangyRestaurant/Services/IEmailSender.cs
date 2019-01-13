using System.Threading.Tasks;

namespace TangyRestaurant.Services
{
    interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
