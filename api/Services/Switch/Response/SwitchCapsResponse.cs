using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SwitchCapsResponse : IResponse
    {
        public SwitchCapsResponse(IEnumerable<SwitchEntity> switches)
        {
            _switches = switches;
        }

        private IEnumerable<SwitchEntity> _switches = null;
        public IEnumerable<SwitchEntity> Switches { get { return _switches; } }

        public bool Success
        {
            get { return true; }
        }
    }
}
