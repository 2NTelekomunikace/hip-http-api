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
    public class SwitchTest
    {
        private readonly ITestOutputHelper _output;

        public SwitchTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Caps()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.SwitchCaps));
            //service
            var switchService = new SwitchService(httpClient.Object);
            //api
            var api = new HIPApi(switchService: switchService);
            //do job
            var response = api.Switch.Caps();
            if (response.Success)
            {
                var resp = (SwitchCapsResponse)response;
                Assert.True(resp.Switches.OfType<SwitchEntity>().Any());
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
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.SwitchStatus));
            //service
            var switchService = new SwitchService(httpClient.Object);
            //api
            var api = new HIPApi(switchService: switchService);
            //do job
            var response = api.Switch.Status();
            if (response.Success)
            {
                var resp = (SwitchStatusResponse)response;
                Assert.True(resp.Switches.OfType<SwitchStatusEntity>().Any());
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
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var switchService = new SwitchService(httpClient.Object);
            //api
            var api = new HIPApi(switchService: switchService);
            //do job
            var response = api.Switch.Ctrl(1, SwitchAction.Trigger, null);
            if (response.Success)
            {
                Assert.IsType<SwitchCtrlResponse>(response);
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
