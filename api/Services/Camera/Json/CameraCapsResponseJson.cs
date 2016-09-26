using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct CameraCapsResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.CameraCapsResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.CameraCapsResponseJson
    {
        internal struct Result
        {
            [JsonProperty("jpegResolution")]
            public List<JpegResolution> Resolutions { get; set; }
            public List<Source> Sources { get; set; }
        }

        internal struct JpegResolution
        {
            public uint Width { get; set; }
            public uint Height { get; set; }
        }

        internal struct Source
        {
            [JsonProperty("source")]
            public string Type { get; set; }
        }
    }
}
