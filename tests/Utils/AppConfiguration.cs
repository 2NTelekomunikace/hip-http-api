using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;

namespace HIPHttpApiTest
{
    public class AppConfiguration
    {
        static string hipAddrKey = "hipAddress";
        static string hipPortKey = "hipPort";
        static string hipUserKey = "hipUser";
        static string hipPwdKey = "hipPwd";
        static string hipTimeoutKey = "timeout";

        public static string HipAddress
        {
            get { return ConfigurationManager.AppSettings[hipAddrKey]; }
        }

        public static ushort HipPort
        {
            get { return Convert.ToUInt16(ConfigurationManager.AppSettings[hipPortKey]); }
        }
        
        public static NetworkCredential HipNetworkCredential
        {
            get { return new NetworkCredential(ConfigurationManager.AppSettings[hipUserKey], ConfigurationManager.AppSettings[hipPwdKey]); }
        }
        
        public static int HipTimeout
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings[hipTimeoutKey]); }
        }
    }
}
