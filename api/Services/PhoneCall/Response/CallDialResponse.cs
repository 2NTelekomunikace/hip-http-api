using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class CallDialResponse : IResponse
    {
        public CallDialResponse(uint session)
        {
            _session = session;
        }

        uint _session;
        public uint Session { get { return _session; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
