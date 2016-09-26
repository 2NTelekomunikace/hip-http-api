using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class AccountEntity
    {
        public uint Id { get; set; }
        public string SipNumber { get; set; }
        public bool Registered { get; set; }
        public DateTime RegisterTime { get; set; }
    }
}
