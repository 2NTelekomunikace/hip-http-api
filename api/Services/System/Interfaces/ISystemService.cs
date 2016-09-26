using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public interface ISystemService : IService
    {
        //System endpoint
        IResponse Info();
        IResponse Status();
        IResponse Restart();

        //Firmware endpoint
        IResponse Firmware(byte[] data);
        IResponse FirmwareApply();

        //Config endpoint
        IResponse ConfigDownload();
        IResponse ConfigUpload(string config);
        IResponse ConfigFactoryReset();

        //Pcap endpoint
        IResponse Pcap();
        IResponse PcapRestart();
        IResponse PcapStop();
    }
}
