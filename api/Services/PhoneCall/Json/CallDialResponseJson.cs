using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct CallDialResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.CallDialResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.CallDialResponseJson
    {
        internal struct Result
        {
            public uint Session { get; set; } 
        }
    }
}
