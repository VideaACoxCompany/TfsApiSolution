using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsApiClient.Services;
using TfsApiService.Services;


namespace TfsApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailer = new SmtpService();
            emailer.SendEmail();
        }
    }
}
