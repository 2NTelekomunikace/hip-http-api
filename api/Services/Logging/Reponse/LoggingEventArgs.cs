using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class LoggingEventArgs : IEventArgs
    {
        public LoggingEventArgs(LoggingServiceFunction function, IResponse response)
        {
            _function = function;
            _response = response;
        }

        IResponse _response;
        public IResponse Response
        {
            get { return _response; }
        }

        LoggingServiceFunction _function;
        public LoggingServiceFunction Function
        {
            get { return _function; }
        }
    }
}
