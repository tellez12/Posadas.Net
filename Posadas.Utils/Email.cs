using System;
using System.Configuration;
using Mailgun.AspNet.Identity;
using Microsoft.AspNet.Identity;
using RestSharp;

namespace Posadas.Utils
{
    //TODO: need to take this credentials out.
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
            request.AddParameter("text", message);
            request.Method = Method.POST;
            client.Execute(request);

        }

        private static IIdentityMessageService _emailService;

        public static IIdentityMessageService MyEmailService
        {
            get
            {
                ////TODO:Need to take credentials out of here. 
                //return _emailService ?? (_emailService = new MailgunMessageService
                //    ("sandboxa869759601c340e5be04ec0e82203c1b.mailgun.org", 
                //    "key-eb4ca3f00570390e1efec891c658786f", 
                //    "luistellez@gmail.com"));

                return _emailService ?? (_emailService = new MailgunMessageService
                   (ConfigurationManager.AppSettings["emailKey"],
                    ConfigurationManager.AppSettings["emailDomain"],
                    ConfigurationManager.AppSettings["emailAdmin"]));

                ;

            }
        }
    }
}