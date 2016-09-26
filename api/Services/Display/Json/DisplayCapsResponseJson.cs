using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct DisplayCapsResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.DisplayCapsResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.DisplayCapsResponseJson
    {
        internal struct Result
        {
            public List<Display> Displays { get; set; }
        }

        internal struct Display
        {
            [JsonProperty("display")]
            public string Type { get; set; }
            public Resolution Resolution { get; set; }
        }

        internal struct Resolution
        {
            public uint Width { get; set; }
            public uint Height { get; set; }
        }
    }
}
