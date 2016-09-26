using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct FirmwareResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.FirmwareResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.FirmwareResponseJson
    {
        internal struct Result
        {
            public string Version { get; set; }
            public bool Downgrade { get; set; }
        }
    }
}
