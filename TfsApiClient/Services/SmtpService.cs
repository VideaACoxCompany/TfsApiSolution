using System;
using System.Configuration;
using System.Net.Mail;

namespace TfsApiClient.Services
{
    public class SmtpService
    {
        public void SendEmail(string body)
        {
            string toAddress = ConfigurationManager.AppSettings.Get("ToAddress");
            using (MailMessage mail = new MailMessage("BranchVerification@videa.tv", toAddress)
            {
                IsBodyHtml = true,
                Subject = "Branch Verification",
                Body = $"{body}  <br/> Date: {DateTime.Now}"

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
