using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Mailgun.AspNet.Identity;
using Mailgun.Messages;
using Microsoft.AspNet.Identity;
using RestSharp;

namespace Posadas.Utils
{
    public static class Email
    {
        public static string ApiKey = ConfigurationManager.AppSettings["emailKey"];
        public static string Domain = ConfigurationManager.AppSettings["emailDomain"];
        public static string From = ConfigurationManager.AppSettings["emailAdmin"];

        public static void SendSimpleMessage(String message)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator = new HttpBasicAuthenticator("api",
                    ApiKey)
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                Domain, ParameterType.UrlSegment);
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
                //if (_emailService == null)
                //{
                //    _emailService = new MailgunMessageService(new MailgunMessageServiceOptions()
                //   {
                //       ApiKey = ApiKey,
                //       Domain = Domain,

                //       UseHtmlBody = true,
                //       DefaultFrom = new Recipient() { Email = From, DisplayName = "Admin" },
                //       DefaultHeaders = new Dictionary<string, string> { { "X-Some-Custom-Header", "Custom" } },
                //       DefaultTags = new Collection<string> { "AuthorizationEmails" }
                //   });

                //}

                if (_emailService == null)
                {
                    _emailService = new MailgunMessageService(Domain, ApiKey, From);


                }
                return _emailService;
               
            }
        }

        public static bool SendMessageWithService(string message)
        {
            message = message + 2;
           MyEmailService.Send(new IdentityMessage()
           {
               Body = message,
               Destination = "luistellez@gmail.com",
               Subject = message
           });
            return true;
        }


    }
}