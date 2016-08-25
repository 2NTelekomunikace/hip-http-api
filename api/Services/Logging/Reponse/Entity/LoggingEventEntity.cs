using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class LoggingEventEntity
    {
        public uint Id { get; set; }
        public int TzShift { get; set; }
        public uint UtcTime { get; set; }
        public uint UpTime { get; set; }
        public LoggingEventName Event { get; set; }
        public ILoggingEventEntityParams Params { get; set; }

        public interface ILoggingEventEntityParams { }

        public class DeviceState : ILoggingEventEntityParams
        {
            public enum StateEnum
            {
                Unknown,
                Startup
            }

            public StateEnum State { get; set; }
        }

        public class AudioLoopTest : ILoggingEventEntityParams
        {
            public enum ResultEnum
            {
                Unknown,
                Passed,
                Failed
            }

            public ResultEnum Result { get; set; }
        }

        public class MotionDetected : ILoggingEventEntityParams
        {
            public enum StateEnum
            {
                Unknown,
                In,
                Out
            }

            public StateEnum State { get; set; }
        }

        public class NoiseDetected : ILoggingEventEntityParams
        {
            public enum StateEnum
            {
                Unknown,
                In,
                Out
            }

            public StateEnum State { get; set; }
        }

        public enum Key
        {
            Unknown,
            Zero = 0,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            QuickDial,
            Star,
            Hatch
        }

        public class KeyPressed : ILoggingEventEntityParams
        {   
            public Key Key { get; set; }
            public uint QuickDialButton { get; set; }
        }

        public class KeyReleased : ILoggingEventEntityParams
        {
            public Key Key { get; set; }
            public uint QuickDialButton { get; set; }
        }

        public class CodeEntered : ILoggingEventEntityParams
        {
            public string Code { get; set; }
            public bool Valid { get; set; }
        }

        public class CardEntered : ILoggingEventEntityParams
        {
            public enum DirectionEnum
            {
                Unknown,
                In,
                Out,
                Any
            }

            public DirectionEnum Direction { get; set; }
            public string Reader { get; set; }
            public string Uid { get; set; }
            public bool Valid { get; set; }
        }

        public class InputChanged : ILoggingEventEntityParams
        {
            public string Port { get; set; }
            public bool State { get; set; }
        }

        public class OutputChanged : ILoggingEventEntityParams
        {
            public string Port { get; set; }
            public bool State { get; set; }
        }

        public class SwitchStateChanged : ILoggingEventEntityParams
        {
            public int Switch { get; set; }
            public bool State { get; set; }
        }

        public class CallStateChanged : ILoggingEventEntityParams
        {
            public enum DirectionEnum
            {
                Unknown,
                Incoming,
                Outgoing
            }

            public enum StateEnum
            {
                Unknown,
                Connecting,
                Ringing,
                Connected,
                Terminated
            }

            public enum ReasonEnum
            {
                Unknown,
                Normal,
                Busy,
                Rejected,
                Noanswer,
                Noresponse,
                CompletedElsewhere,
                Failure
            }

            public DirectionEnum Direction { get; set; }
            public StateEnum State { get; set; }
            public string Peer { get; set; }
            public ReasonEnum Reason { get; set; }
            public uint Session { get; set; }
            public uint Call { get; set; }
        }

        public class RegistrationStateChanged : ILoggingEventEntityParams
        {
            public enum SipAccountEnum
            {
                Unknown,
                First,
                Second
            }

            public enum StateEnum
            {
                Unknown,
                Registered,
                Unregistered,
                Registering,
                Unregistering
            }

            public SipAccountEnum SipAccount { get; set; }
            public StateEnum State { get; set; }
        }

        public class TamperSwitchActivated : ILoggingEventEntityParams
        {
            public enum StateEnum
            {
                Unknown,
                In,
                Out
            }

            public StateEnum State { get; set; }
        }

        public class UnauthorizedDoorOpen : ILoggingEventEntityParams
        {
            public enum StateEnum
            {
                Unknown,
                In,
                Out
            }

            public StateEnum State { get; set; }
        }

        public class DoorOpenTooLong : ILoggingEventEntityParams
        {
            public enum StateEnum
            {
                Unknown,
                In,
                Out
            }

            public StateEnum State { get; set; }
        }

        public class LoginBlocked : ILoggingEventEntityParams
        {
            public string Address { get; set; }
        }
    }
}
