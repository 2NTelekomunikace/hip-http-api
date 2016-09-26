using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class EmailService : IEmailService
    {
        public EmailService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse Send(string to, string subject, string body = null, int? pictureCount = null, uint? width = null, uint? height = null)
        {
            try
            {
                string result = _client.Post(new Uri(EmailEndpoint.Send(to, subject, body, pictureCount, width, height), UriKind.Relative), null);
                EmailSendResponseJson sendResponse = JsonConvert.DeserializeObject<EmailSendResponseJson>(result);

                IResponse response = null;

                if (sendResponse.Success)
                {
                    response = new EmailSendResponse();
                }
                else
                {
                    response = Utils.ErrorResponse(result);
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        IHttpClient _client;
        public IHttpClient Client
        {
            get { return _client; }
        }
    }
}
