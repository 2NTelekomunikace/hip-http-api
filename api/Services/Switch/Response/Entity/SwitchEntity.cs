using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SwitchEntity
    {
        public uint Id { get; set; }
        public bool Enabled { get; set; }
        public SwitchMode Mode { get; set; }
        public uint SwitchOnDuration { get; set; }
        public SwitchType Type { get; set; }
    }
}
