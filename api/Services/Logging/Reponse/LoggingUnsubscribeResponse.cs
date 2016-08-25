using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class LoggingUnsubscribeResponse : IResponse
    {
        public LoggingUnsubscribeResponse()
        {
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
