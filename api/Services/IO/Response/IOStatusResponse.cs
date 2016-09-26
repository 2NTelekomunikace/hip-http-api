using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class IOStatusResponse : IResponse
    {
        public IOStatusResponse(IEnumerable<IOPortStatusEntity> ports)
        {
            _ports = ports;
        }

        IEnumerable<IOPortStatusEntity> _ports;
        public IEnumerable<IOPortStatusEntity> Ports { get { return _ports; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
