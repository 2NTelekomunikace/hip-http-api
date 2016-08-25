using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HIPHttpApi
{
    public interface IHttpClientConfiguration
    {
        IPAddress Address { get; set; }
        ushort Port { get; set; }
        int Timeout { get; set; }
        NetworkCredential NetworCredential { get; set; }
    }
}
