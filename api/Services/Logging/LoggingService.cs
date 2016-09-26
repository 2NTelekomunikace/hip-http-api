using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HIPHttpApi
{
	public class LoggingService : ILoggingService
	{
		public LoggingService(IHttpClient client)
		{
            _client = client;
		}

		public IResponse Caps()
        {
            try
            {
                string result = _client.Get(new Uri(LoggingEndpoint.Caps(), UriKind.Relative));
                CapsResponseJson capsResponse = JsonConvert.DeserializeObject<CapsResponseJson>(result);

                IResponse response = null;

                if (capsResponse.Success)
                {
                    response = new LoggingCapsResponse(capsResponse.Result.Events);
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

        public IResponse Pull(uint id, uint timeout = 0)
        {
            try
            {
                string result = _client.Get(new Uri(LoggingEndpoint.Pull(id, timeout), UriKind.Relative));
                PullResponseJson pullResponse = JsonConvert.DeserializeObject<PullResponseJson>(result);

                IResponse response = null;
                
                if (pullResponse.Success)
                {
                    List<LoggingEventEntity> entities = new List<LoggingEventEntity>();
                    pullResponse.Result.Events.ForEach(x =>
                    {
                        LoggingEventName eventName = Utils.ParseEnum<LoggingEventName>(x.Name);
                        entities.Add(new LoggingEventEntity()
                        {
                            Id = x.Id,
                            TzShift = x.TzShift,
                            UtcTime = x.UtcTime,
                            UpTime = x.UpTime,
                            Event = eventName,
                            Params = GetParams(eventName, x.Params)
                        });
                    });
                    response = new LoggingPullResponse(entities);
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

        public IResponse Subscribe(LoggingSubscribeParamInclude include = LoggingSubscribeParamInclude.New, IEnumerable<LoggingEventName> filter = null, uint duration = 0, int includeTimeOffset = 0)
		{
			try
			{
                string result = _client.Get(new Uri(LoggingEndpoint.Subscribe(include, filter, duration, includeTimeOffset), UriKind.Relative));
                SubscribeJson subscribeResponse = JsonConvert.DeserializeObject<SubscribeJson>(result);

                IResponse response = null;

                if (subscribeResponse.Success)
                {
                    response = new LoggingSubscribeResponse(subscribeResponse.Result.Id);
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

        public IResponse Unsubscribe(uint id)
		{	
			try
			{
                string result = _client.Get(new Uri(LoggingEndpoint.Unsubscribe(id), UriKind.Relative));
                UnsubscribeJson unsubscribeResponse = JsonConvert.DeserializeObject<UnsubscribeJson>(result);

                IResponse response = null;

                if (unsubscribeResponse.Success)
                {
                    response = new LoggingUnsubscribeResponse();
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

        private LoggingEventEntity.ILoggingEventEntityParams GetParams(LoggingEventName eventName, object param)
        {
            LoggingEventEntity.ILoggingEventEntityParams result = null;
            switch (eventName)
            {
                case LoggingEventName.DeviceState:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsDeviceState paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsDeviceState>();

                        result = new LoggingEventEntity.DeviceState()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.DeviceState.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.AudioLoopTest:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsAudioLoopTest paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsAudioLoopTest>();

                        result = new LoggingEventEntity.AudioLoopTest()
                        {
                            Result = Utils.ParseEnum<LoggingEventEntity.AudioLoopTest.ResultEnum>(paramsObj.Result)
                        };
                    }
                    break;
                case LoggingEventName.MotionDetected:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsMotionDetected paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsMotionDetected>();

                        result = new LoggingEventEntity.MotionDetected()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.MotionDetected.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.NoiseDetected:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsNoiseDetected paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsNoiseDetected>();

                        result = new LoggingEventEntity.NoiseDetected()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.NoiseDetected.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.KeyPressed:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsKeyPressed paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsKeyPressed>();

                        LoggingEventEntity.Key key = LoggingEventEntity.Key.Zero;
                        uint quickDialButton = 0;
                        if (paramsObj.Key.StartsWith("%"))
                        {
                            key = LoggingEventEntity.Key.QuickDial;
                            quickDialButton = uint.Parse(paramsObj.Key.Substring(1));
                        }
                        else if (paramsObj.Key == "*")
                        {
                            key = LoggingEventEntity.Key.Star;
                        }
                        else if (paramsObj.Key == "#")
                        {
                            key = LoggingEventEntity.Key.Hatch;
                        }
                        else
                        {
                            uint number = uint.Parse(paramsObj.Key);
                            key = (LoggingEventEntity.Key)number;
                        }

                        result = new LoggingEventEntity.KeyPressed()
                        {
                            Key = key,
                            QuickDialButton = quickDialButton
                        };
                    }
                    break;
                case LoggingEventName.KeyReleased:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsKeyReleased paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsKeyReleased>();

                        LoggingEventEntity.Key key = LoggingEventEntity.Key.Zero;
                        uint quickDialButton = 0;
                        if (paramsObj.Key.StartsWith("%"))
                        {
                            key = LoggingEventEntity.Key.QuickDial;
                            quickDialButton = uint.Parse(paramsObj.Key.Substring(1));
                        }
                        else if (paramsObj.Key == "*")
                        {
                            key = LoggingEventEntity.Key.Star;
                        }
                        else if (paramsObj.Key == "#")
                        {
                            key = LoggingEventEntity.Key.Hatch;
                        }
                        else
                        {
                            uint number = uint.Parse(paramsObj.Key);
                            key = (LoggingEventEntity.Key)number;
                        }

                        result = new LoggingEventEntity.KeyReleased()
                        {
                            Key = key,
                            QuickDialButton = quickDialButton
                        };
                    }
                    break;
                case LoggingEventName.CodeEntered:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsCodeEntered paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsCodeEntered>();

                        result = new LoggingEventEntity.CodeEntered()
                        {
                            Code = paramsObj.Code,
                            Valid = paramsObj.Valid
                        };
                    }
                    break;
                case LoggingEventName.CardEntered:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsCardEntered paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsCardEntered>();

                        result = new LoggingEventEntity.CardEntered()
                        {
                            Direction = Utils.ParseEnum<LoggingEventEntity.CardEntered.DirectionEnum>(paramsObj.Direction),
                            Reader = paramsObj.Reader,
                            Uid = paramsObj.Uid,
                            Valid = paramsObj.Valid
                        };
                    }
                    break;
                case LoggingEventName.InputChanged:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsInputChanged paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsInputChanged>();

                        result = new LoggingEventEntity.InputChanged()
                        {
                            Port = paramsObj.Port,
                            State = paramsObj.State
                        };
                    }
                    break;
                case LoggingEventName.OutputChanged:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsOutputChanged paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsOutputChanged>();

                        result = new LoggingEventEntity.OutputChanged()
                        {
                            Port = paramsObj.Port,
                            State = paramsObj.State
                        };
                    }
                    break;
                case LoggingEventName.SwitchStateChanged:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsSwitchStateChanged paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsSwitchStateChanged>();

                        result = new LoggingEventEntity.SwitchStateChanged()
                        {
                            State = paramsObj.State,
                            Switch = paramsObj.Switch
                        };
                    }
                    break;
                case LoggingEventName.CallStateChanged:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsCallStateChanged paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsCallStateChanged>();

                        result = new LoggingEventEntity.CallStateChanged()
                        {
                            Direction = Utils.ParseEnum<LoggingEventEntity.CallStateChanged.DirectionEnum>(paramsObj.Direction),
                            State = Utils.ParseEnum<LoggingEventEntity.CallStateChanged.StateEnum>(paramsObj.State),
                            Peer = paramsObj.Peer,
                            Reason = Utils.ParseEnum<LoggingEventEntity.CallStateChanged.ReasonEnum>(paramsObj.Reason),
                            Session = paramsObj.Session,
                            Call = paramsObj.Call
                        };
                    }
                    break;
                case LoggingEventName.RegistrationStateChanged:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsRegistrationStateChanged paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsRegistrationStateChanged>();

                        result = new LoggingEventEntity.RegistrationStateChanged()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.RegistrationStateChanged.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.TamperSwitchActivated:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsTamperSwitchActivated paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsTamperSwitchActivated>();

                        result = new LoggingEventEntity.TamperSwitchActivated()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.TamperSwitchActivated.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.UnauthorizedDoorOpen:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsUnauthorizedDoorOpen paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsUnauthorizedDoorOpen>();

                        result = new LoggingEventEntity.UnauthorizedDoorOpen()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.UnauthorizedDoorOpen.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.DoorOpenTooLong:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsDoorOpenTooLong paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsDoorOpenTooLong>();

                        result = new LoggingEventEntity.DoorOpenTooLong()
                        {
                            State = Utils.ParseEnum<LoggingEventEntity.DoorOpenTooLong.StateEnum>(paramsObj.State)
                        };
                    }
                    break;
                case LoggingEventName.LoginBlocked:
                    {
                        JObject jObj = (JObject)param;
                        HIPHttpApi.EventType.ParamsLoginBlocked paramsObj = jObj.ToObject<HIPHttpApi.EventType.ParamsLoginBlocked>();

                        result = new LoggingEventEntity.LoginBlocked()
                        {
                            Address = paramsObj.Address
                        };
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        //pouzi pro asynchronni volani, pokud bude potreba, je v iface IService
        //public event ServiceEventHandler Response;

        private IHttpClient _client;
        public IHttpClient Client
        {
            get { return _client; }
        }
    }
}
