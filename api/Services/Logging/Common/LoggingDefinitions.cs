using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
	internal class LoggingEndpoint
	{
		public static string Caps()
        {
            return "/api/log/caps";
        }

        public static string Subscribe(LoggingSubscribeParamInclude include, IEnumerable<LoggingEventName> filter, uint duration, int includeTimeOffset)
        {
            //base
            string api = "/api/log/subscribe";
            
            //include
            if (include == LoggingSubscribeParamInclude.Time)
                api = string.Concat(api, "?include=", includeTimeOffset);
            else
                api = string.Concat(api, "?include=", include.ToString().ToLower());

            //filter
            if (filter != null)
                api = string.Concat(api, "&filter=", string.Join(",", filter.Select(x => x.ToString())));

            //duration
            if (duration > 0)
                api = string.Concat(api, "&duration=", duration);
            
            return api;
        }

		public static string Unsubscribe(uint id)
        {
            return string.Format("/api/log/unsubscribe?id={0}", id);
        }

        public static string Pull(uint id, uint timeout)
        {
            //base
            string api = "/api/log/pull";
            
            //id
            api = string.Concat(api, "?id=", id);
            
            //timeout
            if (timeout > 0)
                api = string.Concat(api, "&timeout=", timeout);

            return api;
        }
	}

    public enum LoggingEventName
    {
        Unknown,
        DeviceState,
        AudioLoopTest,
        MotionDetected,
        NoiseDetected,
        KeyPressed,
        KeyReleased,
        CodeEntered,
        CardEntered,
        InputChanged,
        OutputChanged,
        SwitchStateChanged,
        CallStateChanged,
        RegistrationStateChanged,
        TamperSwitchActivated,
        UnauthorizedDoorOpen,
        DoorOpenTooLong,
        LoginBlocked
    }

    public enum LoggingSubscribeParamInclude
    {
        New,
        All,
        Time
    }

    public enum LoggingServiceFunction
    {
        Caps,
        Subscribe,
        Unsubsrcibe,
        Pull
    }
}
