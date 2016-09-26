using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct InfoResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.InfoResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.InfoResponseJson
    {
        internal struct Result
        {
            public string Variant { get; set; }
            public string SerialNumber { get; set; }
            public string HwVersion { get; set; }
            public string SwVersion { get; set; }
            public string BuildType { get; set; }
            public string DeviceName { get; set; }
        }
    }
}
