using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Moq;
using HIPHttpApi;

namespace HIPHttpApiTest
{
    public class IOTest
    {
        private readonly ITestOutputHelper _output;

        public IOTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Caps()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.IOCaps));
            //service
            var io = new IOService(httpClient.Object);
            //api
            var api = new HIPApi(io: io);
            //do job
            var response = api.IO.Caps();
            if (response.Success)
            {
                var resp = (IOCapsResponse)response;
                Assert.True(resp.Ports.OfType<IOPortEntity>().Any());
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void Status()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.IOStatus));
            //service
            var io = new IOService(httpClient.Object);
            //api
            var api = new HIPApi(io: io);
            //do job
            var response = api.IO.Status();
            if (response.Success)
            {
                var resp = (IOStatusResponse)response;
                Assert.True(resp.Ports.OfType<IOPortStatusEntity>().Any());
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void Ctrl()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var io = new IOService(httpClient.Object);
            //api
            var api = new HIPApi(io: io);
            //do job
            var response = api.IO.Ctrl("relay1", IOPortAction.On, null);
            if (response.Success)
            {
                Assert.IsType<IOCtrlResponse>(response);
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
