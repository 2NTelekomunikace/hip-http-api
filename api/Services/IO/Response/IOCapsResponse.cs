using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class IOCapsResponse : IResponse
    {
        public IOCapsResponse(IEnumerable<IOPortEntity> ports)
        {
            _ports = ports;
        }

        IEnumerable<IOPortEntity> _ports;
        public IEnumerable<IOPortEntity> Ports { get { return _ports; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
