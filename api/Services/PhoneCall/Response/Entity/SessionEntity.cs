using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SessionEntity
    {
        public uint Id { get; set; }
        public SessionDirection Direction { get; set; }
        public SessionState State { get; set; }
    }
}
