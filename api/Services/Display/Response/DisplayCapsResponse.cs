using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class DisplayCapsResponse : IResponse
    {
        public DisplayCapsResponse(IEnumerable<DisplayEntity> displays)
        {
            _displays = displays;
        }

        IEnumerable<DisplayEntity> _displays;
        public IEnumerable<DisplayEntity> Displays
        {
            get { return _displays; }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
