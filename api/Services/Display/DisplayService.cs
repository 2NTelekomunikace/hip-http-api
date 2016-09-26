using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class DisplayService : IDisplayService
    {
        public DisplayService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse Caps()
        {
            try
            {
                string result = _client.Get(new Uri(DisplayEndpoint.Caps(), UriKind.Relative));
                DisplayCapsResponseJson capsResponse = JsonConvert.DeserializeObject<DisplayCapsResponseJson>(result);

                IResponse response = null;

                if (capsResponse.Success)
                {
                    List<DisplayEntity> displays = new List<DisplayEntity>();
                    capsResponse.Result.Displays.ForEach(d =>
                    {
                        displays.Add(new DisplayEntity()
                        {
                            Type = Utils.ParseEnum<DisplayType>(d.Type),
                            Width = d.Resolution.Width,
                            Height = d.Resolution.Height
                        });
                    });

                    response = new DisplayCapsResponse(displays);
                }
                else
                {
                    response = Utils.ErrorResponse(result);
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public IResponse ImageUpload(DisplayType display, byte[] gifImageData)
        {
            try
            {
                string result = _client.Put(new Uri(DisplayEndpoint.Image(display), UriKind.Relative), gifImageData);
                DisplayImageResponseJson imageResponse = JsonConvert.DeserializeObject<DisplayImageResponseJson>(result);

                IResponse respone = null;

                if (imageResponse.Success)
                {
                    respone = new DisplayImageResponse();
                }
                else
                {
                    respone = Utils.ErrorResponse(result);
                }

                return respone;
            }
            catch
            {
                throw;
            }
        }

        public IResponse ImageDelete(DisplayType display)
        {
            try
            {
                string result = _client.Delete(new Uri(DisplayEndpoint.Image(display), UriKind.Relative), null);
                DisplayImageResponse imageResponse = JsonConvert.DeserializeObject<DisplayImageResponse>(result);

                IResponse response = null;

                if (imageResponse.Success)
                {
                    response = new DisplayImageResponse();
                }
                else
                {
                    response = Utils.ErrorResponse(result);
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
