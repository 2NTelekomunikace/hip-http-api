using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface IEmailService : IService
    {
        IResponse Send(string to, string subject, string body = null, int? pictureCount = null, uint? width = null, uint? height = null);
    }
}
