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
    public class DisplayTest
    {
        private readonly ITestOutputHelper _output;

        public DisplayTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Caps()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.DisplayCaps));
            //service
            var display = new DisplayService(httpClient.Object);
            //api
            var api = new HIPApi(display: display);
            //do job
            var response = api.Display.Caps();
            if (response.Success)
            {
                var resp = (DisplayCapsResponse)response;
                Assert.True(resp.Displays.OfType<DisplayEntity>().Any());
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void ImageUpload()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Put(It.IsAny<Uri>(), It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var display = new DisplayService(httpClient.Object);
            //api
            var api = new HIPApi(display: display);
            //do job
            var response = api.Display.ImageUpload(DisplayType.Internal, new byte[16]);
            if (response.Success)
            {
                Assert.IsType<DisplayImageResponse>(response);
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void ImageDelete()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Delete(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var display = new DisplayService(httpClient.Object);
            //api
            var api = new HIPApi(display: display);
            //do job
            var response = api.Display.ImageDelete(DisplayType.Internal);
            if (response.Success)
            {
                Assert.IsType<DisplayImageResponse>(response);
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
