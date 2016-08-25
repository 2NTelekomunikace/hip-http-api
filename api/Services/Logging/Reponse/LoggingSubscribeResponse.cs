using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class LoggingSubscribeResponse : IResponse
    {
        public LoggingSubscribeResponse(uint id)
        {
            _id = id;
        }

        uint _id;
        public uint Id
        {
            get { return _id; }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
