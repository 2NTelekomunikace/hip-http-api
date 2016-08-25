using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct ErrorResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.ErrorResponse.Error Error { get; set; }
    }

    namespace HIPHttpApi.ErrorResponse
    {
        internal struct Error
        {
            public int Code { get; set; }
            public string Param { get; set; }
            public string Description { get; set; }
        }
    }
}
