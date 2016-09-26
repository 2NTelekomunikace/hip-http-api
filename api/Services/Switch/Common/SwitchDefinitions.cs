using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class SwitchEndpoint
    {
        public static string Caps(int? switchId)
        {
            string api = "/api/switch/caps";

            if (switchId.HasValue)
                api = string.Concat(api, "/?switch=", switchId);

            return api;
        }

        internal static string Status(int? switchId)
        {
            string api = "/api/switch/status";

            if (switchId.HasValue)
                api = string.Concat(api, "/?switch=", switchId);

            return api;
        }

        internal static string Ctrl(int switchId, SwitchAction action, string response)
        {
            string api = "/api/switch/ctrl";

            api = string.Concat(api, "?switch=", switchId);
            api = string.Concat(api, "&action=", action.ToString().ToLower());
            if (response != null)
                api = string.Concat(api, "&response=", response);

            return api;
        }
    }

    public enum SwitchMode
    {
        Unknown,
        Monostable,
        Bistable
    }

    public enum SwitchType
    {
        Unknown,
        Normal,
        Security
    }

    public enum SwitchAction
    {
        On,
        Off,
        Trigger
    }
}
