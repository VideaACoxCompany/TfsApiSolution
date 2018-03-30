using System;
using System.Net.Mail;

namespace TfsApiClient.Services
{
    public class SmtpService
    {
        public void SendEmail()
        {
            using (MailMessage mail = new MailMessage("BranchVerification@videa.tv", "johnny.chu@videa.tv")
            {
                IsBodyHtml = true,
                Subject = "this is a test email.",
                Body = "this is my test email body" + DateTime.Now

            })
            {
                using (SmtpClient client = new SmtpClient()
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                    Host = "webmail.coxmediagroup.com"
                })
                {
                    client.Send(mail);
                }
            }
        }
    }
}
