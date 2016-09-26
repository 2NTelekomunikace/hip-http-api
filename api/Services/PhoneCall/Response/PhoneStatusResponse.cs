using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPHttpApi
{
    public class PhoneStatusResponse : IResponse
    {
        public PhoneStatusResponse(IEnumerable<AccountEntity> accounts)
        {
            _accounts = accounts;
        }

        IEnumerable<AccountEntity> _accounts;
        public IEnumerable<AccountEntity> Accounts
        {
            get { return _accounts; }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}
