using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface IPhoneCallService : IService
    {
        IResponse PhoneStatus(uint? account = null);
        IResponse CallStatus(uint? session = null);
        IResponse CallDial(string number);
        IResponse CallAnswer(uint session);
        IResponse CallHangup(uint session, HangupReason reason = HangupReason.Normal);
    }
}
