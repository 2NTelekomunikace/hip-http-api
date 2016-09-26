using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HIPHttpApi
{
    internal struct StatusResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.StatusResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.StatusResponseJson
    {
        internal struct Result
        {
            [JsonConverter(typeof(UnixTimeConverter))]
            public DateTime SystemTime { get; set; }
            public int UpTime { get; set; }
        }
    }
}
