using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TangyRestaurant.Utility;
using TangyRestaurant.Services;

namespace TangyRestaurant.Extensions
{
    public static class EmailSenderExtensions
    {
        //Method for sending mails for email confirmations
        public static Task SendEmailConfirmationAsync(this EmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Plese confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>Link</a>");
        }

        //Method for sending mails for forgotted password
        public static Task SendPasswordEmailAsync(this EmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(
                    email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(link)}'>clicking here</a>.");
        }

        //Method is sending mails for status change
        public static Task SendOrderStatusAsync(this EmailSender emailSender, string email, string orderNumber, string status)
        {
            string subject = "";
            string message = "";

            switch (status)
            {
                case SD.StatusCancelled:
                    subject = "Order Cancelled";
                    message = "<p>Order Number : <strong>" + orderNumber + "</strong> has been Cancelled!</p> <p>Please contact us if you have any questions.</p>";
                    break;

                case SD.StatusSubmitted:
                    subject = "Order Submitted Successfully";
                    message = "<p>Order Number : <strong>" + orderNumber + "</strong> has been submitted successfully!</p> <p>Please contact us if you have any questions.</p>";
                    break;

                case SD.StatusReady:
                    subject = "Order Ready for Pickup";
                    message = "<p>Order Number : <strong>" + orderNumber + "</strong> is now ready for pickup!</p> <p>Please contact us if you have any questions.</p>";
                    break;

                case SD.StatusCompleted:
                    subject = "Order Completed Successfully";
                    message = "<p>Order Number : <strong>" + orderNumber + "</strong> is completed successfully!</p><p>Please contact us if you have any questions.</p>";
                    break;

                case SD.StatusInProcess:
                    subject = "Order Being Prepared";
                    message = "<p>Order Number : <strong>" + orderNumber + "</strong> is in progress!</p><p>Please contact us if you have any questions.</p>";
                    break;

                default:
                    break;
            }

            return emailSender.SendEmailAsync(
                email,
                subject,
                message);
        }
        
    }
}
