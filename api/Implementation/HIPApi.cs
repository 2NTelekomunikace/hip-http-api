using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class HIPApi : IApi
    {
        public HIPApi(ILoggingService logging = null, ISystemService system = null, ISwitchService switchService = null, IIOService io = null, IPhoneCallService phoneCall = null, ICameraService camera = null, IDisplayService display = null, IAudioService audio = null, IEmailService email = null)
        {
            _logging = logging;
            _system = system;
            _switch = switchService;
            _io = io;
            _phoneCall = phoneCall;
            _camera = camera;
            _display = display;
            _audio = audio;
            _email = email;
        }

        private IEmailService _email;
        public IEmailService Email
        {
            get { return _email; }
        }

        private IAudioService _audio;
        public IAudioService Audio
        {
            get { return _audio; }
        }

        private IDisplayService _display;
        public IDisplayService Display
        {
            get { return _display; }
        }

        private ICameraService _camera;
        public ICameraService Camera
        {
            get { return _camera; }
        }

        private IPhoneCallService _phoneCall;
        public IPhoneCallService PhoneCall
        {
            get { return _phoneCall; }
        }

        private IIOService _io;
        public IIOService IO
        {
            get { return _io; }
        }

        private ISwitchService _switch;
        public ISwitchService Switch
        {
            get { return _switch; }
        }

        private ISystemService _system;
        public ISystemService System
        {
            get { return _system; }
        }

        private ILoggingService _logging;
        public ILoggingService Logging
        {
            get { return _logging; }
        }
    }
}
