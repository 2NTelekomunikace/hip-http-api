using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class LoggingPullResponse : IResponse
    {
        public LoggingPullResponse(IEnumerable<LoggingEventEntity> events)
        {
            _events = events;
        }

        IEnumerable<LoggingEventEntity> _events = null;
        public IEnumerable<LoggingEventEntity> Events
        {
            get { return _events; }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
