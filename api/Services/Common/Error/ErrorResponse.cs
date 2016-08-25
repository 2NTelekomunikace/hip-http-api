using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class ErrorResponse : IResponse
    {
        public ErrorResponse(int code, string param, string description)
        {
            Code = code;
            Param = param;
            Description = description;
        }

        public int Code { get; private set; }
        public string Param { get; private set; }
        public string Description { get; private set; }

        public bool Success
        {
            get { return false; }
        }
    }
}
