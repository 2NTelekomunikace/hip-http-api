using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface ILoggingService : IService
    {
        IResponse Caps();
        IResponse Subscribe(LoggingSubscribeParamInclude include = LoggingSubscribeParamInclude.New, IEnumerable<LoggingEventName> filter = null, uint duration = 0, int includeTimeOffset = 0);
        IResponse Unsubscribe(uint id);
        IResponse Pull(uint id, uint timeout = 0);
    }
}
