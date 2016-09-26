using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct SwitchStatusResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.SwitchStatusResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.SwitchStatusResponseJson
    {
        internal struct Result
        {
            public List<SwitchStatus> Switches { get; set; }
        }

        internal struct SwitchStatus
        {
            [JsonProperty("switch")]
            public uint Id { get; set; }
            public bool Active { get; set; }
        }
    }
}
