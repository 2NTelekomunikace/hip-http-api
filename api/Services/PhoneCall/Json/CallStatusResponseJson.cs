using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct CallStatusResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.CallStatusResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.CallStatusResponseJson
    {
        internal struct Result
        {
            public List<Session> Sessions { get; set; }
        }

        internal struct Session
        {
            [JsonProperty("session")]
            public uint Id { get; set; }
            public string Direction { get; set; }
            public string State { get; set; }
        }
    }
}
