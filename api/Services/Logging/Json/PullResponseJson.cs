using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
	internal struct PullResponseJson
	{
		public bool Success { get; set; }
		public HIPHttpApi.EventType.Result Result { get; set; }
	}

    namespace HIPHttpApi.EventType
    {
        internal struct Result
        {
            public List<LoggingEventJson> Events { get; set; }
        }

        internal struct LoggingEventJson
        {
            public uint Id { get; set; }
            public uint UtcTime { get; set; }
            public uint UpTime { get; set; }
            public int TzShift { get; set; }
            [JsonProperty("Event")]
            public string Name { get; set; }
            public object Params { get; set; }
        }

        internal struct ParamsDeviceState
        {
            public string State { get; set; }
        }

        internal struct ParamsAudioLoopTest
        {
            public string Result { get; set; }
        }

        internal struct ParamsMotionDetected
        {
            public string State { get; set; }
        }

        internal struct ParamsNoiseDetected
        {
            public string State { get; set; }
        }

        internal struct ParamsKeyPressed
        {
            public string Key { get; set; }
        }

        internal struct ParamsKeyReleased
        {
            public string Key { get; set; }
        }

        internal struct ParamsCodeEntered
        {
            public string Code { get; set; }
            public bool Valid { get; set; }
        }

        internal struct ParamsCardEntered
        {
            public string Direction { get; set; }
            public string Reader { get; set; }
            public string Uid { get; set; }
            public bool Valid { get; set; }
        }

        internal struct ParamsInputChanged
        {
            public string Port { get; set; }
            public bool State { get; set; }
        }

        internal struct ParamsOutputChanged
        {
            public string Port { get; set; }
            public bool State { get; set; }
        }

        internal struct ParamsSwitchStateChanged
        {
            public int Switch { get; set; }
            [JsonConverter(typeof(IntToBoolJsonConverter))]
            public bool State { get; set; }
        }

        internal struct ParamsCallStateChanged
        {
            public string Direction { get; set; }
            public string State { get; set; }
            public string Peer { get; set; }
            public string Reason { get; set; }
            public uint Session { get; set; }
            public uint Call { get; set; }
        }

        internal struct ParamsRegistrationStateChanged
        {
            public uint SipAccount { get; set; }
            public string State { get; set; }
        }

        internal struct ParamsTamperSwitchActivated
        {
            public string State { get; set; }
        }

        internal struct ParamsUnauthorizedDoorOpen
        {
            public string State { get; set; }
        }

        internal struct ParamsDoorOpenTooLong
        {
            public string State { get; set; }
        }

        internal struct ParamsLoginBlocked
        {
            public string Address { get; set; }
        }
    }

    internal class IntToBoolJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}
