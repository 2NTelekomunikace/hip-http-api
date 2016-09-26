using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class SystemEndpoint
    {
        internal static string Info()
        {
            return "/api/system/info";
        }

        internal static string Status()
        {
            return "/api/system/status";
        }

        internal static string Restart()
        {
            return "/api/system/restart";
        }

        internal static string Firmware()
        {
            return "/api/firmware";
        }

        internal static string FirmwareApply()
        {
            return "/api/firmware/apply";
        }

        internal static string Config()
        {
            return "/api/config";
        }

        internal static string ConfigFactoryReset()
        {
            return "/api/config/factoryreset";
        }

        internal static string Pcap()
        {
            return "/api/pcap";
        }

        internal static string PcapRestart()
        {
            return "/api/pcap/restart";
        }

        internal static string PcapStop()
        {
            return "/api/pcap/stop";
        }
    }
}
