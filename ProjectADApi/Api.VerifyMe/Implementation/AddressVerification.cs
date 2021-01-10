using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Implementation
{
    public class AddressVerification : IVerificationManager
    {
        public string _address;
        public AddressVerification(string Address) => _address = Address;
        
        public void Verify()
        {
            throw new NotImplementedException();
        }

    }
}
