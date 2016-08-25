using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface IEventArgs
    {
        IResponse Response { get; }
    }
}
