using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HIPHttpApi
{
    public class SystemConfigDownloadResponse : IResponse
    {
        public SystemConfigDownloadResponse(XDocument config)
        {
            _config = config;
        }

        private XDocument _config;
        public XDocument Config { get { return _config; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
