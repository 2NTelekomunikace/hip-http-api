using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIPHttpApi;
using Xunit;
using Xunit.Abstractions;
using Moq;

namespace HIPHttpApiTest.Services.PhoneCall
{
    public class PhoneCallTest
    {
        private readonly ITestOutputHelper _output;

        public PhoneCallTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void PhoneStatusTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.PhoneStatus));

            //service
            var phoneCall = new PhoneCallService(httpClient.Object);
            //api
            var api = new HIPApi(phoneCall: phoneCall);
            //do the job
            var response = api.PhoneCall.PhoneStatus();
            if (response.Success)
            {
                var resp = (PhoneStatusResponse)response;
                Assert.True(resp.Accounts.OfType<AccountEntity>().Any());
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void CallStatusTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.CallStatus));

            //service
            var phoneCall = new PhoneCallService(httpClient.Object);
            //api
            var api = new HIPApi(phoneCall: phoneCall);
            //do the job
            var response = api.PhoneCall.CallStatus();
            if (response.Success)
            {
                var resp = (CallStatusResponse)response;
                Assert.True(resp.Sessions.OfType<SessionEntity>().Any());
                var session = resp.Sessions.First();
                Assert.True(session.Id == 1);
                Assert.True(session.Direction == SessionDirection.Outgoing);
                Assert.True(session.State == SessionState.Ringing);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void CallDialTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.CallDial));

            //service
            var phoneCall = new PhoneCallService(httpClient.Object);
            //api
            var api = new HIPApi(phoneCall: phoneCall);
            //do the job
            var response = api.PhoneCall.CallDial("123456789");
            if (response.Success)
            {
                var resp = (CallDialResponse)response;
                Assert.True(resp.Session == 2);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void CallAnswerTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var phoneCall = new PhoneCallService(httpClient.Object);
            //api
            var api = new HIPApi(phoneCall: phoneCall);
            //do the job
            var response = api.PhoneCall.CallAnswer(3);
            if (response.Success)
            {
                Assert.IsType<CallAnswerResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void CallHangupTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var phoneCall = new PhoneCallService(httpClient.Object);
            //api
            var api = new HIPApi(phoneCall: phoneCall);
            //do the job
            var response = api.PhoneCall.CallHangup(3);
            if (response.Success)
            {
                Assert.IsType<CallHangupResponse>(response);
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
