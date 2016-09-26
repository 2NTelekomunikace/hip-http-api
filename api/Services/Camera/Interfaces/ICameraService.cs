using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface ICameraService : IService
    {
        IResponse Caps();
        IResponse Snapshot(uint width, uint height, CameraSource source = CameraSource.Internal);
    }
}
