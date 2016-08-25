using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal class Utils
    {
        internal static TEnum ParseEnum<TEnum>(string value) where TEnum : struct
        {
            TEnum result;
            Enum.TryParse<TEnum>(value, true, out result);
            return result;
        }
    }
}
