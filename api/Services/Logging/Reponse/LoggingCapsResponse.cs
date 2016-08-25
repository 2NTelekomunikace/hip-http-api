using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class LoggingCapsResponse : IResponse
    {
        public LoggingCapsResponse(IEnumerable<LoggingEventName> events)
        {
            _events = events;
        }

        IEnumerable<LoggingEventName> _events = null;
        public IEnumerable<LoggingEventName> Events { get { return _events; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
