using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SystemFirmwareResponse : IResponse
    {
        public SystemFirmwareResponse(Version version, bool downgrade)
        {
            _version = version;
            _downgrade = downgrade;
        }

        private bool _downgrade;
        public bool Downgrade { get { return _downgrade; } }

        private Version _version;
        public Version Version { get { return _version; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
