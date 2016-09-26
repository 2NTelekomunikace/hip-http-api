using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class DisplayEndpoint
    {
        public static string Caps()
        {
            return "/api/display/caps";
        }

        internal static string Image(DisplayType display)
        {
            string api = "/api/display/image";

            string.Concat(api, "?display=", display.ToString().ToLower());

            return api;
        }
    }

    public enum DisplayType
    {
        Unknown,
        Internal,
        External
    }
}
