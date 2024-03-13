using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Transversal
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string from, string to, string subject, string message)
        {

            MailMessage mailMessage = new MailMessage(from, to, subject, message);
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            smtpClient.PickupDirectoryLocation = @"C:\Email.FriendsTown";
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Send(mailMessage);
        }
    }
}
