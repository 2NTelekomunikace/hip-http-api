using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class IOEndpoint
    {
        public static string Caps(string port)
        {
            string api = "/api/io/caps";

            if (!string.IsNullOrEmpty(port))
                api = string.Concat(api, "?port=", port);

            return api;
        }

        internal static string Status(string port)
        {
            string api = "/api/io/status";

            if (!string.IsNullOrEmpty(port))
                api = string.Concat(api, "?port=", port);

            return api;
        }

        internal static string Ctrl(string port, IOPortAction action, string response)
        {
            string api = "/api/ioPctrl";

            api = string.Concat(api, "?port=", port);
            api = string.Concat(api, "&action=", action.ToString().ToLower());
            if (string.IsNullOrEmpty(response))
                api = string.Concat(api, "&response=", response);

            return api;
        }
    }

    public enum IOPortType
    {
        Unknown,
        Input,
        Output
    }

    public enum IOPortAction
    {
        On,
        Off
    }
}
