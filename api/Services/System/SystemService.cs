using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HIPHttpApi
{
    public class SystemService : ISystemService
    {
        public SystemService(IHttpClient client)
        {
            _client = client;
        }

        #region System Endpoint
        public IResponse Info()
        {
            try
            {
                string result = _client.Get(new Uri(SystemEndpoint.Info(), UriKind.Relative));
                InfoResponseJson infoResponse = JsonConvert.DeserializeObject<InfoResponseJson>(result);

                IResponse response = null;

                if (infoResponse.Success)
                {
                    var infoEntity = new SystemInfoEntity()
                    {
                        Variant = infoResponse.Result.Variant,
                        SerialNumber = infoResponse.Result.SerialNumber,
                        HwVersion = infoResponse.Result.HwVersion,
                        SwVersion = new Version(infoResponse.Result.SwVersion),
                        BuildType = infoResponse.Result.BuildType,
                        DeviceName = infoResponse.Result.DeviceName
                    };

                    response = new SystemInfoResponse(infoEntity);
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

        public IResponse Status()
        {
            try
            {
                string result = _client.Get(new Uri(SystemEndpoint.Status(), UriKind.Relative));
                StatusResponseJson statusResponse = JsonConvert.DeserializeObject<StatusResponseJson>(result);

                IResponse response = null;

                if (statusResponse.Success)
                {
                    response = new SystemStatusResponse(statusResponse.Result.SystemTime, statusResponse.Result.UpTime);
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

        public IResponse Restart()
        {
            try
            {
                string result = _client.Post(new Uri(SystemEndpoint.Restart(), UriKind.Relative), null);
                RestartResponseJson restartResponse = JsonConvert.DeserializeObject<RestartResponseJson>(result);

                IResponse response = null;

                if (restartResponse.Success)
                {
                    response = new SystemRestartResponse();
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
        #endregion

        #region Firmware Endpoint
        public IResponse Firmware(byte[] data)
        {
            try
            {
                string result = _client.Put(new Uri(SystemEndpoint.Firmware(), UriKind.Relative), data);
                FirmwareResponseJson firmwareResponse = JsonConvert.DeserializeObject<FirmwareResponseJson>(result);

                IResponse response = null;

                if (firmwareResponse.Success)
                {
                    response = new SystemFirmwareResponse(new Version(firmwareResponse.Result.Version), firmwareResponse.Result.Downgrade);
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

        public IResponse FirmwareApply()
        {
            try
            {
                string result = _client.Get(new Uri(SystemEndpoint.FirmwareApply(), UriKind.Relative));
                FirmwareApplyResponseJson firmwareApplyResponse = JsonConvert.DeserializeObject<FirmwareApplyResponseJson>(result);

                IResponse response = null;

                if (firmwareApplyResponse.Success)
                {
                    response = new SystemFirmwareApplyResponse();
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
        #endregion

        #region Config Endpoint
        public IResponse ConfigDownload()
        {
            try
            {
                string result = _client.Get(new Uri(SystemEndpoint.Config(), UriKind.Relative));
                XDocument config = null;
                try
                {
                    config = XDocument.Parse(result);
                }
                catch {}

                IResponse response = null;

                if (config != null)
                {
                    response = new SystemConfigDownloadResponse(config);
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

        public IResponse ConfigUpload(string config)
        {
            try
            {
                string result = _client.Put(new Uri(SystemEndpoint.Config(), UriKind.Relative), config);
                ConfigUploadResponseJson configResponse = JsonConvert.DeserializeObject<ConfigUploadResponseJson>(result);

                IResponse response = null;

                if (configResponse.Success)
                {
                    response = new SystemConfigUploadResponse();
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

        public IResponse ConfigFactoryReset()
        {
            try
            {
                string result = _client.Post(new Uri(SystemEndpoint.ConfigFactoryReset(), UriKind.Relative), null);
                ConfigFactoryResetResponseJson configResponse = JsonConvert.DeserializeObject<ConfigFactoryResetResponseJson>(result);

                IResponse response = null;

                if (configResponse.Success)
                {
                    response = new SystemConfigFactoryResetResponse();
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
        #endregion

        #region Pcap Endpoint
        public IResponse Pcap()
        {
            try
            {
                byte[] result = _client.GetBytes(new Uri(SystemEndpoint.Pcap(), UriKind.Relative));

                IResponse response = null;

                try
                {
                    response = Utils.ErrorResponse(Encoding.UTF8.GetString(result));
                }
                catch { }

                if (response == null)
                {
                    response = new SystemPcapResponse(result);
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public IResponse PcapRestart()
        {
            try
            {
                string result = _client.Post(new Uri(SystemEndpoint.PcapRestart(), UriKind.Relative), null);
                PcapRestartResponseJson pcapResponse = JsonConvert.DeserializeObject<PcapRestartResponseJson>(result);

                IResponse response = null;

                if (pcapResponse.Success)
                {
                    response = new SystemPcapRestartResponse();
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

        public IResponse PcapStop()
        {
            try
            {
                string result = _client.Post(new Uri(SystemEndpoint.PcapStop(), UriKind.Relative), null);
                PcapStopResponseJson pcapResponse = JsonConvert.DeserializeObject<PcapStopResponseJson>(result);

                IResponse response = null;

                if (pcapResponse.Success)
                {
                    response = new SystemPcapStopResponse();
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
        #endregion

        private IHttpClient _client;
        public IHttpClient Client
        {
            get { return _client; }
        }
    }
}
