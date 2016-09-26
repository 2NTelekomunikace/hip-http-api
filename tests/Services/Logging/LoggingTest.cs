using HIPHttpApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Moq;

namespace HIPHttpApiTest
{
    public class LoggingTest
    {
        private readonly ITestOutputHelper _output;

        public LoggingTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CapsTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Caps));
            //service
            var logging = new LoggingService(httpClient.Object);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            var response = api.Logging.Caps();
            if (response.Success)
            {
                var resp = (LoggingCapsResponse)response;
                Assert.True(resp.Events.Count() == 17);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void SubscribeTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Subscribe));
            //service
            var logging = new LoggingService(httpClient.Object);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            var response = api.Logging.Subscribe();
            if (response.Success)
            {
                var resp = (LoggingSubscribeResponse)response;
                Assert.Equal<uint>(2121013117, resp.Id);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void UnsubscribeTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var logging = new LoggingService(httpClient.Object);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            var response = api.Logging.Unsubscribe(123);
            if (response.Success)
            {
                Assert.IsType<LoggingUnsubscribeResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void PullTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Pull));
            //service
            var logging = new LoggingService(httpClient.Object);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            var response = api.Logging.Pull(123);
            if (response.Success)
            {
                var resp = (LoggingPullResponse)response;
                var events = resp.Events;
                Assert.True(events.Any());
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
