using Api.VerifyMe.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe
{
   public abstract class DefaultVerificationFactory
    {
        public abstract IVerificationManager CreateInstance(string WhatToVerify);        
    }
}
