using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class HIPApi : IApi
    {
        public HIPApi(ILoggingService logging = null)
        {
            _logging = logging;
        }

        private ILoggingService _logging;
        public ILoggingService Logging
        {
            get { return _logging; }
        }
    }
}
