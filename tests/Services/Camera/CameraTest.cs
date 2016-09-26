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
    public class CameraTest
    {
        private readonly ITestOutputHelper _output;

        public CameraTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Caps()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Get(It.IsAny<Uri>())).Returns(Encoding.UTF8.GetString(Properties.Resources.CameraCaps));
            //service
            var camera = new CameraService(httpClient.Object);
            //api
            var api = new HIPApi(camera: camera);
            //do job
            var response = api.Camera.Caps();
            if (response.Success)
            {
                var resp = (CameraCapsResponse)response;
                Assert.True(resp.Resolutions.OfType<JpegResolutionEntity>().Any());
                Assert.True(resp.Sources.OfType<CameraSource>().Any());
            }
            else
            {
                var resp = (ErrorResponse)response;
                _output.WriteLine(resp.Description);
                Assert.True(false);
            }
        }

        [Fact]
        public void Snapshot()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.GetBytes(It.IsAny<Uri>())).Returns(() =>
            {
                MemoryStream ms = new MemoryStream();
                Properties.Resources.CameraSnapshot.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] result = ms.ToArray();
                ms.Close();

                return result;
            });
            //service
            var camera = new CameraService(httpClient.Object);
            //api
            var api = new HIPApi(camera: camera);
            //do job
            var response = api.Camera.Snapshot(640, 480);
            if (response.Success)
            {
                var resp = (CameraSnapshotResponse)response;
                Assert.NotNull(resp.Image);
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
