using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class EmailEndpoint
    {
        public static string Send(string to, string subject, string body, int? pictureCount, uint? width, uint? height)
        {
            string api = "/api/email/send";

            api = string.Concat(api, "?to=", to);
            api = string.Concat(api, "&subject=", subject);
            
            if (!string.IsNullOrEmpty(body))
                api = string.Concat(api, "&body=", body);

            if (pictureCount.HasValue && pictureCount.Value > 0)
                api = string.Concat(api, "&pictureCount=", pictureCount);

            if (width.HasValue && width.Value > 0 && height.HasValue && height.Value > 0)
            {
                api = string.Concat(api, "&width=", width);
                api = string.Concat(api, "&height=", height);
            }

            return api;
        }
    }
}
