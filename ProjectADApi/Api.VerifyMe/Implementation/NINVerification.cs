using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Implementation
{
    public class NINVerification : IVerificationManager
    {
        public string _Nin;

       public NINVerification (string NIN)
        {
            _Nin = NIN;
        }       
       

        public void Verify()
        {
            throw new NotImplementedException();
        }
    }
}
