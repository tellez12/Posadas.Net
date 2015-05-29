using System;
using Mailgun.AspNet.Identity;
using Microsoft.AspNet.Identity;
using RestSharp;

namespace Posadas.Utils
{
    public static class Email
    {
        public static void SendSimpleMessage(String message)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator = new HttpBasicAuthenticator("api",
                    "key-eb4ca3f00570390e1efec891c658786f")
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                "sandboxa869759601c340e5be04ec0e82203c1b.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <test@icloud.com>");
            request.AddParameter("to", "Luis Tellez <mequedoen@gmail.com>");
            request.AddParameter("subject", "Hello Luis Tellez");
            request.AddParameter("text",
                "Congratulations Luis Tellez, you just sent an email with Mailgun!  You are truly awesome!  You can see a record of this email in your logs: https://mailgun.com/cp/log .  You can send up to 300 emails/day from this sandbox server.  Next, you should add your own domain so you can send 10,000 emails/month for free. " +
                message);
            request.Method = Method.POST;
            client.Execute(request);

        }

        private static IIdentityMessageService _emailService;

        public static IIdentityMessageService MyEmailService
        {
            get { return _emailService ?? (_emailService = new MailgunMessageService("domain", "apiKey", "")); }
        }
    }
}