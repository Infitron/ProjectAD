using Api.VerifyMe.Core;
using Api.VerifyMe.Implementation;
using Api.VerifyMe.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Factory
{
    public class NINVerificationFactory : DefaultVerificationFactory
    {
        public override IVerificationManager CreateInstance(object WhatToVerify) => new NINVerification((GenericVerifyMeRequest)WhatToVerify);
        
    }
}
