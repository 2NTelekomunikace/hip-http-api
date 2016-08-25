using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct CapsResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.CapsResponse.Result Result { get; set; }
    }

    namespace HIPHttpApi.CapsResponse
    {
        internal class Result
        {
            public List<LoggingEventName> Events { get; set; }
        }
    }
}
