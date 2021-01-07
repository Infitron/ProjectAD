using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Core
{
   public interface IVerifyMe
    {
        void VerifyMe(WhatToVerify WhatToVerify, string VerifyIt);
    }

    public enum WhatToVerify
    {
        NIN = 1,
        BVN = 2,
        Passport = 3,
        Address = 4,
        AccountNmber = 5
    }
}
