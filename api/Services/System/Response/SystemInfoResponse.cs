using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SystemInfoResponse : IResponse
    {
        public SystemInfoResponse(SystemInfoEntity info)
        {
            _info = info;
        }

        private SystemInfoEntity _info;
        public SystemInfoEntity Info { get { return _info; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
