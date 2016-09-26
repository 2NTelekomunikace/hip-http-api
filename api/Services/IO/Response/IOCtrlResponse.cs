using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class IOCtrlResponse : IResponse
    {
        public IOCtrlResponse(string response)
        {
            _response = response;
        }

        string _response;
        public string Response { get; set; }

        public bool Success
        {
            get { return true; }
        }
    }
}
