using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Implementation
{
    public class BVNVerification : IVerificationManager
    {
        public string _Bvn;

        public BVNVerification(string BVN) => _Bvn = BVN;

        public void Verify()
        {
            throw new NotImplementedException();
        }       
    }
}
