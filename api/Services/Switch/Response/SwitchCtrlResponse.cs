using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SwitchCtrlResponse : IResponse
    {
        public SwitchCtrlResponse(string response)
        {
            _response = response;
        }

        string _response;
        public string Response { get { return _response; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
