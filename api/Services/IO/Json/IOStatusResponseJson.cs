using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct IOStatusResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.IOStatusResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.IOStatusResponseJson
    {
        internal struct Result
        {
            public List<Port> Ports { get; set; }
        }

        internal struct Port
        {
            [JsonProperty("port")]
            public string Name { get; set; }
            public int State { get; set; }
        }
    }
}
