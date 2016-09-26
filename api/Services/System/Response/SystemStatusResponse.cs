using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SystemStatusResponse : IResponse
    {
        public SystemStatusResponse(DateTime systemTime, int upTime)
        {
            _systemTime = systemTime;
            _upTime = upTime;
        }

        private DateTime _systemTime;
        public DateTime SystemTime { get { return _systemTime; } }
        private int _upTime;
        public int UpTime { get { return _upTime; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
