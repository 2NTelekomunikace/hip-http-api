using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SwitchStatusResponse : IResponse
    {
        public SwitchStatusResponse(IEnumerable<SwitchStatusEntity> switches)
        {
            _switches = switches;
        }

        IEnumerable<SwitchStatusEntity> _switches;
        public IEnumerable<SwitchStatusEntity> Switches { get { return _switches; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
