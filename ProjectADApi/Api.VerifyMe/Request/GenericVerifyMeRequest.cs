using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Request
{
    public class GenericVerifyMeRequest
    {
        public string WhatToVerify { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dob { get; set; }
    }
}
