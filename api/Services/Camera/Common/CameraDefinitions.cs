using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class CameraEndpoint
    {
        internal static string Caps()
        {
            return "/api/camera/caps";
        }

        internal static string Snapshot(uint width, uint height, CameraSource source)
        {
            string api = "/api/camera/snapshot";

            api = string.Concat(api, "?width=", width);
            api = string.Concat(api, "&height=", height);
            api = string.Concat(api, "&source=", source.ToString().ToLower());

            return api;
        }
    }

    public enum CameraSource
    {
        Unknown,
        Internal,
        External
    }
}
