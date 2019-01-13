using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TangyRestaurant.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message) //we receive parameters
        {

            //01. Create a client, the host is "gmail" and the port is "578"
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            //02. Specify Client Credentials :
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("atanasskambitovv@gmail.com", "LELEMALE!!!");
            client.EnableSsl = true;


            //03. Create the Message
            MailMessage mailMessage = new MailMessage();

            //04. Assign everything to the message
            mailMessage.From = new MailAddress("atanasskambitovv@gmail.com");
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            mailMessage.To.Add(email);
            mailMessage.IsBodyHtml = true;


            //Send the mail
            client.Send(mailMessage);
            
            return Task.CompletedTask;
        }
    }
}
