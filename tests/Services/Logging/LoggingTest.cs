using HIPHttpApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace HIPHttpApiTest
{
    public class LoggingTest
    {
        private readonly ITestOutputHelper _output;

        uint subId = 0;

        string ipAddr = AppConfiguration.HipAddress;
        ushort port = AppConfiguration.HipPort;
        NetworkCredential credent = AppConfiguration.HipNetworkCredential;
        int timeout = AppConfiguration.HipTimeout;

        public LoggingTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CapsTest()
        {
            //client
            var httpClient = new HttpClient(new HttpClientConfiguration()
            {
                Address = IPAddress.Parse(ipAddr),
                Port = port,
                NetworCredential = credent,
                Timeout = timeout
            });
            //service
            var logging = new LoggingService(httpClient);
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
            var httpClient = new HttpClient(new HttpClientConfiguration()
            {
                Address = IPAddress.Parse(ipAddr),
                Port = port,
                NetworCredential = credent,
                Timeout = timeout
            });
            //service
            var logging = new LoggingService(httpClient);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            var subRsp = api.Logging.Subscribe();
            if (subRsp.Success)
            {
                var resp = (LoggingSubscribeResponse)subRsp;
                subId = resp.Id;
            }
            else
            {
                var resp = (ErrorResponse)subRsp;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }

            var unsubRsp = api.Logging.Unsubscribe(subId);
            if (unsubRsp.Success)
            {
                var resp = (LoggingUnsubscribeResponse)unsubRsp;
                Assert.True(true);
            }
            else
            {
                var resp = (ErrorResponse)unsubRsp;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void UnsubscribeTest()
        {
            //client
            var httpClient = new HttpClient(new HttpClientConfiguration()
            {
                Address = IPAddress.Parse(ipAddr),
                Port = port,
                NetworCredential = credent,
                Timeout = timeout
            });
            //service
            var logging = new LoggingService(httpClient);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            api.Logging.Subscribe();
            api.Logging.Unsubscribe(subId);
        }

        [Fact]
        public void PullTest()
        {
            //client
            var httpClient = new HttpClient(new HttpClientConfiguration()
            {
                Address = IPAddress.Parse(ipAddr),
                Port = port,
                NetworCredential = credent,
                Timeout = timeout
            });
            //service
            var logging = new LoggingService(httpClient);
            //api
            var api = new HIPApi(logging: logging);
            //do job
            var subRsp = api.Logging.Subscribe();
            if (subRsp.Success)
            {
                var resp = (LoggingSubscribeResponse)subRsp;
                subId = resp.Id;
            }
            else
            {
                var resp = (ErrorResponse)subRsp;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }

            var pullRsp = api.Logging.Pull(subId);
            if (pullRsp.Success)
            {
                var resp = (LoggingPullResponse)pullRsp;
                var events = resp.Events;
                Assert.True(true);
            }
            else
            {
                var resp = (ErrorResponse)pullRsp;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }

            var unsubRsp = api.Logging.Unsubscribe(subId);
            if (unsubRsp.Success)
            {
                var resp = (LoggingUnsubscribeResponse)unsubRsp;
                Assert.True(true);
            }
            else
            {
                var resp = (ErrorResponse)unsubRsp;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }
    }
}
