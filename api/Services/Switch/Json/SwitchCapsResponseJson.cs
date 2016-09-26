using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct SwitchCapsResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.SwitchCapsResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.SwitchCapsResponseJson
    {
        internal struct Result
        {
            public List<Switch> Switches { get; set; }
        }

        internal struct Switch
        {
            [JsonProperty("switch")]
            public uint Id { get; set; }
            public bool Enabled { get; set; }
            public string Mode { get; set; }
            public uint SwitchOnDuration { get; set; }
            public string Type { get; set; }
        }
    }
}
