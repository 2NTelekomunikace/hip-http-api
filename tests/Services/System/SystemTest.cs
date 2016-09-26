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
    public class SystemTest
    {
        private readonly ITestOutputHelper _output;

        public SystemTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void InfoTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            string test = Encoding.UTF8.GetString(Properties.Resources.SystemInfo);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(test);
            
            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.Info();
            if (response.Success)
            {
                var resp = (SystemInfoResponse)response;
                Assert.Equal("2N Helios IP Vario", resp.Info.Variant);
                Assert.Equal("08-1860-0035", resp.Info.SerialNumber);
                Assert.Equal("535v1", resp.Info.HwVersion);
                Assert.True(new HIPHttpApi.Version("2.10.0.19.2") == resp.Info.SwVersion);
                Assert.Equal("beta", resp.Info.BuildType);
                Assert.Equal("2N Helios IP Vario", resp.Info.DeviceName);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void StatusTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.SystemStatus));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.Status();
            if (response.Success)
            {
                var resp = (SystemStatusResponse)response;
                Assert.Equal<DateTime>(new DateTime(1970, 1, 17, 9, 57, 5, 91), resp.SystemTime);
                Assert.Equal<int>(190524, resp.UpTime);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void Restart()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.Restart();
            if (response.Success)
            {
                Assert.IsType<SystemRestartResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void FirmwareTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Put(It.IsAny<Uri>(), It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Firmware));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.Firmware(new byte[] { 0, 1, 2, 3, 4, 5 });
            if (response.Success)
            {
                var resp = (SystemFirmwareResponse)response;
                Assert.True(new HIPHttpApi.Version("2.10.0.19.2") == resp.Version);
                Assert.False(resp.Downgrade);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void FirmwareApplyTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.FirmwareApply();
            if (response.Success)
            {
                Assert.IsType<SystemFirmwareApplyResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void ConfigDownloadTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Properties.Resources.Config);

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.ConfigDownload();
            if (response.Success)
            {
                var resp = (SystemConfigDownloadResponse)response;
                Assert.NotNull(resp.Config);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void ConfigUploadTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Put(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.ConfigUpload(Properties.Resources.Config);
            if (response.Success)
            {
                Assert.IsType<SystemConfigUploadResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void ConfigFactoryResetTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.ConfigFactoryReset();
            if (response.Success)
            {
                Assert.IsType<SystemConfigFactoryResetResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void PcapTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.GetBytes(It.IsAny<Uri>())).Returns(new byte[] { 0 });

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.Pcap();
            if (response.Success)
            {
                var resp = (SystemPcapResponse)response;
                Assert.Equal<byte>(0, resp.PcapData[0]);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void PcapRestartTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.PcapRestart();
            if (response.Success)
            {
                Assert.IsType<SystemPcapRestartResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void PcapStopTest()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));

            //service
            var system = new SystemService(httpClient.Object);
            //api
            var api = new HIPApi(system: system);
            //do the job
            var response = api.System.PcapStop();
            if (response.Success)
            {
                Assert.IsType<SystemPcapStopResponse>(response);
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
