using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HIPHttpApi
{
    public class HttpClientConfiguration : IHttpClientConfiguration
    {
        private IPAddress _address;
        public IPAddress Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        private ushort _port;
        public ushort Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        NetworkCredential _networkCredential;
        public NetworkCredential NetworCredential
        {
            get
            {
                return _networkCredential;
            }
            set
            {
                _networkCredential = value;
            }
        }

        private int _timeout;
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
    }
}
