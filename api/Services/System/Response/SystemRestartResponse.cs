using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SystemRestartResponse : IResponse
    {
        public bool Success
        {
            get { return true; }
        }
    }
}
