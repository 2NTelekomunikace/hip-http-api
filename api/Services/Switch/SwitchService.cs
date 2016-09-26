using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SwitchService : ISwitchService
    {
        public SwitchService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse Caps(int? switchId = null)
        {
            try
            {
                string result = _client.Get(new Uri(SwitchEndpoint.Caps(switchId), UriKind.Relative));
                SwitchCapsResponseJson capsResponse = JsonConvert.DeserializeObject<SwitchCapsResponseJson>(result);

                IResponse response = null;

                if (capsResponse.Success)
                {
                    List<SwitchEntity> switches = new List<SwitchEntity>();
                    capsResponse.Result.Switches.ForEach(sw =>
                    {
                        switches.Add(new SwitchEntity()
                        {
                            Id = sw.Id,
                            Enabled = sw.Enabled,
                            Mode = Utils.ParseEnum<SwitchMode>(sw.Mode),
                            SwitchOnDuration = sw.SwitchOnDuration,
                            Type = Utils.ParseEnum<SwitchType>(sw.Mode)
                        });
                    });

                    response = new SwitchCapsResponse(switches);
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

        public IResponse Status(int? switchId = null)
        {
            try
            {
                string result = _client.Get(new Uri(SwitchEndpoint.Status(switchId), UriKind.Relative));
                SwitchStatusResponseJson statusResponse = JsonConvert.DeserializeObject<SwitchStatusResponseJson>(result);

                IResponse response = null;

                if (statusResponse.Success)
                {
                    List<SwitchStatusEntity> switches = new List<SwitchStatusEntity>();
                    statusResponse.Result.Switches.ForEach(sw =>
                    {
                        switches.Add(new SwitchStatusEntity()
                        {
                            Id = sw.Id,
                            Active = sw.Active
                        });
                    });

                    response = new SwitchStatusResponse(switches);
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

        public IResponse Ctrl(int switchId, SwitchAction action, string response = null)
        {
            try
            {
                string result = _client.Get(new Uri(SwitchEndpoint.Ctrl(switchId, action, response), UriKind.Relative));

                IResponse iResponse = null;

                if (response != null)
                {
                    iResponse = new SwitchCtrlResponse(response);
                }
                else
                {
                    SwitchCtrlResponseJson ctrlResponse = JsonConvert.DeserializeObject<SwitchCtrlResponseJson>(result);

                    if (ctrlResponse.Success)
                    {
                        iResponse = new SwitchCtrlResponse(null);
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

        private IHttpClient _client;
        public IHttpClient Client
        {
            get { return _client; }
        }
    }
}