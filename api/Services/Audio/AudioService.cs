using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class AudioService : IAudioService
    {
        public AudioService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse Test()
        {
            try
            {
                string result = _client.Post(new Uri(AudioEndpoint.Test(), UriKind.Relative), null);
                AudioTestResponseJson testResponse = JsonConvert.DeserializeObject<AudioTestResponseJson>(result);

                IResponse resposne = null;

                if (testResponse.Success)
                {
                    resposne = new AudioTestResponse();
                }
                else
                {
                    resposne = Utils.ErrorResponse(result);
                }

                return resposne;
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
