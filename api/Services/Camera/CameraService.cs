using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class CameraService : ICameraService
    {
        public CameraService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse Caps()
        {
            string result = _client.Get(new Uri(CameraEndpoint.Caps(), UriKind.Relative));
            CameraCapsResponseJson capsResponse = JsonConvert.DeserializeObject<CameraCapsResponseJson>(result);

            IResponse response = null;

            if (capsResponse.Success)
            {
                List<JpegResolutionEntity> resolutions = new List<JpegResolutionEntity>();
                List<CameraSource> sources = new List<CameraSource>();

                capsResponse.Result.Resolutions.ForEach(res =>
                {
                    resolutions.Add(new JpegResolutionEntity()
                    {
                        Width = res.Width,
                        Height = res.Height
                    });
                });

                capsResponse.Result.Sources.ForEach(src =>
                {
                    sources.Add(Utils.ParseEnum<CameraSource>(src.Type));
                });

                response = new CameraCapsResponse(resolutions, sources);
            }
            else
            {
                response = Utils.ErrorResponse(result);
            }

            return response;
        }

        public IResponse Snapshot(uint width, uint height, CameraSource source = CameraSource.Internal)
        {
            try
            {
                byte[] result = _client.GetBytes(new Uri(CameraEndpoint.Snapshot(width, height, source), UriKind.Relative));

                Image img = null;
                try
                {
                    MemoryStream ms = new MemoryStream(result);
                    img = Image.FromStream(ms, false, true);
                    ms.Close();
                }
                catch { }

                IResponse response = null;

                if (img != null)
                {
                    response = new CameraSnapshotResponse(img);
                }
                else
                {
                    response = Utils.ErrorResponse(Encoding.UTF8.GetString(result));
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        IHttpClient _client;
        public IHttpClient Client
        {
            get { return _client; }
        }
    }
}
