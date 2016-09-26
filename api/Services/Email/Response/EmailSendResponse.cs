using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class EmailSendResponse : IResponse
    {
        public bool Success
        {
            get { return true; }
        }
    }
}
