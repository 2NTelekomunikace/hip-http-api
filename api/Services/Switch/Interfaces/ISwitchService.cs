using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface ISwitchService : IService
    {
        IResponse Caps(int? switchId = null);
        IResponse Status(int? switchId = null);
        IResponse Ctrl(int switchId, SwitchAction action, string response = null);
    }
}
