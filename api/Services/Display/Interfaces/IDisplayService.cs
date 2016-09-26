using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface IDisplayService : IService
    {
        IResponse Caps();
        IResponse ImageUpload(DisplayType display, byte[] gifImageData);
        IResponse ImageDelete(DisplayType display);
    }
}
