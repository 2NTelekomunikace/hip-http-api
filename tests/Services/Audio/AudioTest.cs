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
    public class AudioTest
    {
        private readonly ITestOutputHelper _output;

        public AudioTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test()
        {
            //client
            var httpClient = new Mock<IHttpClient>(MockBehavior.Strict);
            httpClient.Setup(x => x.Post(It.IsAny<Uri>(), It.IsAny<string>())).Returns(Encoding.UTF8.GetString(Properties.Resources.Success));
            //service
            var audio = new AudioService(httpClient.Object);
            //api
            var api = new HIPApi(audio: audio);
            //do job
            var response = api.Audio.Test();
            if (response.Success)
            {
                Assert.IsType<AudioTestResponse>(response);
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
