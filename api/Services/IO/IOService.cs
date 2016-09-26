using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class IOService : IIOService
    {
        public IOService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse Caps(string port = null)
        {
            try
            {
                string result = _client.Get(new Uri(IOEndpoint.Caps(port), UriKind.Relative));
                IOCapsResponseJson capsResponse = JsonConvert.DeserializeObject<IOCapsResponseJson>(result);

                IResponse response = null;

                if (capsResponse.Success)
                {
                    List<IOPortEntity> ports = new List<IOPortEntity>();
                    capsResponse.Result.Ports.ForEach(p =>
                    {
                        ports.Add(new IOPortEntity()
                        {
                            Name = p.Name,
                            Type = Utils.ParseEnum<IOPortType>(p.Type)
                        });
                    });

                    response = new IOCapsResponse(ports);
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

        public IResponse Status(string port = null)
        {
            try
            {
                string result = _client.Get(new Uri(IOEndpoint.Status(port), UriKind.Relative));
                IOStatusResponseJson statusResponse = JsonConvert.DeserializeObject<IOStatusResponseJson>(result);

                IResponse respone = null;

                if (statusResponse.Success)
                {
                    List<IOPortStatusEntity> ports = new List<IOPortStatusEntity>();
                    statusResponse.Result.Ports.ForEach(p =>
                    {
                        ports.Add(new IOPortStatusEntity()
                        {
                            Name = p.Name,
                            State = p.State == 1 ? true : false
                        });
                    });

                    respone = new IOStatusResponse(ports);
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

        public IResponse Ctrl(string port, IOPortAction action, string response)
        {
            try
            {
                string result = _client.Post(new Uri(IOEndpoint.Ctrl(port, action, response), UriKind.Relative), null);

                IResponse iResponse = null;

                if (response != null)
                {
                    iResponse = new IOCtrlResponse(response);
                }
                else
                {
                    IOCtrlResponse ctrlResponse = JsonConvert.DeserializeObject<IOCtrlResponse>(result);

                    if (ctrlResponse.Success)
                    {
                        iResponse = new IOCtrlResponse(null);
                    }
                    else
                    {
                        iResponse = Utils.ErrorResponse(result);
                    }
                }

                return iResponse;
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
