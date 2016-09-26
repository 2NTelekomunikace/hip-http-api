using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class SystemInfoEntity
    {
        public string Variant { get; set; }
        public string SerialNumber { get; set; }
        public string HwVersion { get; set; }
        public Version SwVersion { get; set; }
        public string BuildType { get; set; }
        public string DeviceName { get; set; }
    }
}
