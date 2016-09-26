using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class CameraCapsResponse : IResponse
    {
        public CameraCapsResponse(IEnumerable<JpegResolutionEntity> resolutions, IEnumerable<CameraSource> sources)
        {
            _resolutions = resolutions;
            _sources = sources;
        }

        IEnumerable<CameraSource> _sources;
        public IEnumerable<CameraSource> Sources
        {
            get { return _sources; }
        }

        IEnumerable<JpegResolutionEntity> _resolutions;
        public IEnumerable<JpegResolutionEntity> Resolutions
        {
            get { return _resolutions; }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
