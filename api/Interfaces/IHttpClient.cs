using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HIPHttpApi
{
    public interface IHttpClient
    {
        string Get(Uri endpoint);
        string Post(Uri endpoint, string payload);
        string Put(Uri endpoint, string payload);
        string Delete(Uri endpoint, string payload);
    }
}
