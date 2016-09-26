using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Moq;
using HIPHttpApi;
using System.IO;

namespace HIPHttpApiTest
{
    public class EmailTest
    {
        private readonly ITestOutputHelper _output;

        public EmailTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Caps()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var email = new EmailService(httpClient.Object);
            //api
            var api = new HIPApi(email: email);
            //do job
            var response = api.Email.Send("somebody@email.com", "subject");
            if (response.Success)
            {
                Assert.IsType<EmailSendResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }
    }
}
