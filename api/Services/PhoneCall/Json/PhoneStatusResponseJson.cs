using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    internal struct PhoneStatusResponseJson
    {
        public bool Success { get; set; }
        public HIPHttpApi.PhoneStatusResponseJson.Result Result { get; set; }
    }

    namespace HIPHttpApi.PhoneStatusResponseJson
    {
        internal struct Result
        {
            public List<Account> Accounts { get; set; }
        }

        internal struct Account
        {
            [JsonProperty("account")]
            public uint Id { get; set; }
            public string SipNumber { get; set; }
            public bool Registered { get; set; }
            [JsonConverter(typeof(UnixTimeConverter))]
            public DateTime RegisterTime { get; set; }
        }
    }
}
