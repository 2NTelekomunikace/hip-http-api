using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SystemPcapResponse : IResponse
    {
        public SystemPcapResponse(byte[] data)
        {
            _pcapData = data;
        }

        byte[] _pcapData = null;
        public byte[] PcapData { get { return _pcapData; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
