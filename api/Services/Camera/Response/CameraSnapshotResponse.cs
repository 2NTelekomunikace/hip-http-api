using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class CameraSnapshotResponse : IResponse
    {
        public CameraSnapshotResponse(Image image)
        {
            _image = image;
        }

        Image _image;
        public Image Image
        {
            get { return _image; }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
